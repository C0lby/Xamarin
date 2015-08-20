using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Foundation;
using UIKit;

namespace HttpPostImage
{
	
	public static class NSMutableDataExtensions
	{
		public static void AppendString (this NSMutableData data, string str)
		{
			data.AppendData(NSData.FromString(str, NSStringEncoding.UTF8));
		}
	}


	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base(handle)
		{
		}


		static string postUrl = "http://my.post.url", username = "username", password = "password", filename = "snapshot";


		public async override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear(animated);

			var image = UIImage.FromBundle("test_screenshot");

			// post the image using HttpClient
			var responseH = await postImageWithHttpClient(image, filename);
			Console.WriteLine(responseH);

			// post the image using NSUrlSession
			var responseS = await postImageWithNSUrlSession(image, filename);
			Console.WriteLine(responseS);
		}


		public async Task<string> postImageWithHttpClient (UIImage image, string filename)
		{
			var uri = new Uri (postUrl);

			var boundary = string.Format($"Boundary-{Guid.NewGuid()}");

			var body = new MultipartFormDataContent ();

			body.Add(new StringContent (string.Format($"--{boundary}\r\n")));

			body.Add(new ByteArrayContent (image.AsJPEG().ToArray()), "file", string.Format($"{filename}.jpeg"));

			body.Add(new StringContent (string.Format($"\r\n--{boundary}--\r\n")));

			var credentials = NSData.FromString(string.Format("{0}:{1}", username, password), NSStringEncoding.UTF8).GetBase64EncodedString(NSDataBase64EncodingOptions.None);

			try {
				
				using (var client = new HttpClient ()) {
				
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", credentials);
				
					using (var response = await client.PostAsync(uri, body)) {
					
						if (response.IsSuccessStatusCode)
							using (var content = response.Content)
								return await content.ReadAsStringAsync();
					}
				}

			} catch (Exception ex) {
				
				Console.WriteLine(ex.Message);

			}

			return "nothing";
		}


		public Task<string> postImageWithNSUrlSession (UIImage image, string filename)
		{
			var nsUrl = NSUrl.FromString("http://my.post.url");

			var body = new NSMutableData ();

			var session = NSUrlSession.FromConfiguration(NSUrlSessionConfiguration.DefaultSessionConfiguration);

			var boundary = string.Format($"Boundary-{Guid.NewGuid()}");

			body.AppendString(string.Format($"--{boundary}\r\n"));

			body.AppendString(string.Format($"Content-Disposition: form-data; name=\"file\"; filename=\"{filename}.jpeg\"\r\n"));

			body.AppendString("Content-Type: image/jpeg\r\n\r\n");

			body.AppendData(image.AsJPEG());

			body.AppendString(string.Format($"\r\n--{boundary}--\r\n"));

			var contentType = string.Format($"multipart/form-data; boundary={boundary}");

			var credentials = NSData.FromString(string.Format("{0}:{1}", username, password), NSStringEncoding.UTF8).GetBase64EncodedString(NSDataBase64EncodingOptions.None);

			var authHeader = string.Format($"Basic {credentials}");

			var requestHeaderDict = NSDictionary.FromObjectsAndKeys(
				                        new [] { contentType, authHeader }, 
				                        new [] { "Content-Type", "Authorization" }
			                        );

			var request = new NSMutableUrlRequest (nsUrl) {
				HttpMethod = "POST",
				Headers = requestHeaderDict
			};

			request.Body = body;

			var tcs = new TaskCompletionSource<string> ();

			var task = session.CreateDataTask(request, (data, response, error) => {

				try {
					
					if (error != null) throw new Exception (error.LocalizedDescription);

					var httpResponse = response as NSHttpUrlResponse;

					// Ok = 200  |  Created = 201
					if (response != null && (httpResponse.StatusCode == 200 || httpResponse.StatusCode == 201)) {

						tcs.SetResult(data?.ToString() ?? "nothing1");
					}

				} catch (Exception ex) {

					// tcs.SetException(ex);
					Console.WriteLine(ex.Message);

					tcs.SetResult("nothing1");
				}

			});

			task.Resume();

			return tcs.Task;
		}
	}
}