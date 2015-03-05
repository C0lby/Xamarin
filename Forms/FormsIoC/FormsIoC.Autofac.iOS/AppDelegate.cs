using Foundation;
using UIKit;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services;

namespace FormsIoC.Autofac.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public ServicesProvider provider { get; set; }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			// should only call this once
			Bootstrap.Run ();

			provider = Resolver.Resolve<ServicesProvider> ();

			waitThenTest ();

			return base.FinishedLaunching (app, options);
		}

		async void waitThenTest ()
		{
			await Task.Delay (1000);

			provider.PrintLn ("Provider Works!");
			provider.TestSettings ();
		}
	}
}