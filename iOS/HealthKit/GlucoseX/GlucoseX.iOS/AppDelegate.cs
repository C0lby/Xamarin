using Foundation;
using UIKit;

namespace GlucoseX.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }



		public override void OnActivated (UIApplication application)
		{
			// HealthKitProvider.ValidateAuthorizationAsync ();
		}


		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{

			// UITabBar.Appearance.TintColor = UIColor.FromRGB (73, 231, 194);
			// UITabBar.Appearance.TintColor = UIColor.FromRGB (255, 68, 17);

			UITabBar.Appearance.TintColor = UIColor.FromRGB(252f / 255f, 17f / 255f, 63f / 255f);

			return true;
		}
	}
}

