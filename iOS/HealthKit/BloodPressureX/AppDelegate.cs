using Foundation;
using UIKit;
using Xamarin;

namespace BloodPressureX
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }


		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Insights.Initialize("d7db00028548dd71bc134680dd0176e9709dd078");

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			Settings.Synchronize();
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// HealthKitProvider.ValidateAuthorizationAsync ();
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}