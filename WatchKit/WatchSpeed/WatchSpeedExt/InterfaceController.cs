using System;

using WatchKit;
using Foundation;
using CoreLocation;

namespace WatchSpeedExt
{

	public partial class InterfaceController : WKInterfaceController
	{
		NSTimer timer;

		readonly NSString statusKey = new NSString("status");

		readonly NSString speedKey = new NSString("speed");

		readonly NSString speedUnitKey = new NSString("speedUnit");

		readonly NSString courseCardinalKey = new NSString("courseCardinal");

		readonly NSString courseDegreesKey = new NSString("courseDegrees");

		readonly NSString northUnitKey = new NSString("northUnit");


		public InterfaceController (IntPtr handle) : base (handle)
		{
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			timer = NSTimer.CreateRepeatingScheduledTimer (1, UpdateUserInterface);

			UpdateUserInterface (timer);

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context", this);
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}


		void UpdateUserInterface (NSTimer t)
		{
			WKInterfaceController.OpenParentApplication (new NSDictionary(), (replyInfo, error) => {
				if (error != null) {
					Console.WriteLine (error);
					return;
				}
					
				var status = (CLAuthorizationStatus)((NSNumber)replyInfo[statusKey]).UInt32Value;


				switch (status) {
				
					case CLAuthorizationStatus.AuthorizedAlways:

						var speedValue = replyInfo[speedKey].ToString ();
						var speedUnitValue = replyInfo[speedUnitKey].ToString ();
						var courseCardinalValue = replyInfo[courseCardinalKey].ToString ();
						var courseDegreesValue = replyInfo[courseDegreesKey].ToString ();
						var northUnitValue = replyInfo[northUnitKey].ToString ();

						updateSpeed (speedValue, speedUnitValue);
						updateCourse (courseCardinalValue, courseDegreesValue, northUnitValue);

						break;

					case CLAuthorizationStatus.NotDetermined:
					case CLAuthorizationStatus.Denied:

						displayLocationServicesError ();

						break;

					default:
						throw new NotImplementedException();
				}
			});
		}


		void updateSpeed (string speed, string unit)
		{
			SpeedValueLabel.SetText (speed);
			SpeedUnitLabel.SetText (unit);
		}


		void updateCourse (string cardinal, string degrees, string north, bool locationDisabled = false)
		{
			CogValueCardinalLabel.SetText (cardinal);
			CogValueDegreeLabel.SetText (degrees);

			NorthValueLabel.SetText (north);

			CogLabel.SetText (locationDisabled ? "Location Unavailable" : "COG");
		}


		void displayLocationServicesError ()
		{
			updateSpeed ("--", string.Empty);

			updateCourse (string.Empty, string.Empty, string.Empty, true);
		}
	}
}