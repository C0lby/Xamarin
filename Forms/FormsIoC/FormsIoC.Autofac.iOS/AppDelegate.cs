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

			Bootstrap.Run ();

			provider = Resolver.Resolve<ServicesProvider> ();

			waitThenInject ();

			return base.FinishedLaunching (app, options);
		}

		async void waitThenInject ()
		{
			await Task.Delay (1000);

			provider.PrintLn ("Provider Works!");
			provider.TestSettings ();
		}
	}
}