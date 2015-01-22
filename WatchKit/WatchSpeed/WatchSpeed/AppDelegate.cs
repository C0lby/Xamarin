using Foundation;
using UIKit;
using CoreLocation;
using System.Linq;
using System;

namespace WatchSpeed
{

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		CLLocationManager locationManager;

		NSString speedValue, speedUnitValue, courseCardinalValue, courseDegreesValue;

		readonly NSString statusKey = new NSString("status");

		readonly NSString speedKey = new NSString("speed");

		readonly NSString speedUnitKey = new NSString("speedUnit");

		readonly NSString courseCardinalKey = new NSString("courseCardinal");

		readonly NSString courseDegreesKey = new NSString("courseDegrees");

		readonly NSString northUnitKey = new NSString("northUnit");


		public override UIWindow Window { get; set; }


		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{

			// if (UIApplication.SharedApplication.ApplicationState == UIApplicationState.Active)
			initializeGps ();

			return true;
		}


		public override void WillEnterForeground (UIApplication application)
		{
			initializeGps ();
		}


		public override void DidEnterBackground (UIApplication application)
		{
			if (locationManager != null)
				locationManager.StopUpdatingLocation ();
		}


		bool initializeLocationManager ()
		{
			if (locationManager == null) {
				locationManager = new CLLocationManager();
				locationManager.ShouldDisplayHeadingCalibration += m => false;
			}

			if (CLLocationManager.Status == CLAuthorizationStatus.NotDetermined)
				locationManager.RequestAlwaysAuthorization ();

			return CLLocationManager.Status == CLAuthorizationStatus.AuthorizedAlways && CLLocationManager.LocationServicesEnabled;
		}


		//NSTimer timer;
		//
		//void UpdateUserInterface (NSTimer t)
		//{
		//	Console.WriteLine ("speedUnitValue = {0}", speedUnitValue);
		//	Console.WriteLine ("speedValue = {0}", speedValue);
		//	Console.WriteLine ("courseDegreesValue = {0}", courseDegreesValue);
		//	Console.WriteLine ("courseCardinalValue = {0}", courseCardinalValue);
		//}


		void initializeGps ()
		{
			if (initializeLocationManager ()) {
				locationManager.LocationsUpdated += HandleLocationsUpdated;
				locationManager.StartUpdatingLocation ();

				// timer = NSTimer.CreateRepeatingScheduledTimer (5, UpdateUserInterface);
				// UpdateUserInterface (timer);

			} else {
				locationManager.AuthorizationChanged += HandleAuthorizationChanged;
			}
		}


		void HandleLocationsUpdated (object sender, CLLocationsUpdatedEventArgs e)
		{
			var location = e.Locations.LastOrDefault ();

			if (location == null)
				return;

			if (location.Speed >= 0)
				updateSpeed (location.Speed);

			if (location.Course >= 0)
				updateCog (location.Course);
		}


		void updateSpeed (double speed)
		{
			Console.WriteLine ("speedUnitValue = {0}", UomManager.GetSpeedPreferredUnit ());
			speedUnitValue = new NSString(UomManager.GetSpeedPreferredUnit ());
			Console.WriteLine ("speedValue = {0}", UomManager.GetSpeedInPreferredUnit (speed).ToString ());
			speedValue = new NSString(UomManager.GetSpeedInPreferredUnit (speed).ToString ());
		}

		void updateCog (double course)
		{
			Console.WriteLine ("courseDegreesValue = {0}", course.ToDegreeString ());
			courseDegreesValue = new NSString(course.ToDegreeString ());
			Console.WriteLine ("courseCardinalValue = {0}", course.ToDirectionString ());
			courseCardinalValue = new NSString(course.ToDirectionString ());
		}

		void HandleAuthorizationChanged (object sender, CLAuthorizationChangedEventArgs e)
		{
			locationManager.AuthorizationChanged -= HandleAuthorizationChanged;

			initializeGps ();
		}

		public override void HandleWatchKitExtensionRequest (UIApplication application, NSDictionary userInfo, Action<NSDictionary> reply)
		{
			reply (new NSDictionary(
				statusKey, NSNumber.FromUInt32 ((uint)CLLocationManager.Status),
				speedKey, speedValue,
				speedUnitKey, speedUnitValue,
				courseCardinalKey, courseCardinalValue,
				courseDegreesKey, courseDegreesValue,
				northUnitKey, new NSString(UomManager.GetTrueNorthPrefferedUnit ())
			));
		}
	}
}