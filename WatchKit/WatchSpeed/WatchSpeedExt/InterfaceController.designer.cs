// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using Foundation;
using System.CodeDom.Compiler;

namespace WatchSpeedExt
{

	[Register ("InterfaceController")]
	partial class InterfaceController
	{
		[Outlet]
		WatchKit.WKInterfaceLabel CogLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceLabel CogValueCardinalLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceLabel CogValueDegreeLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceLabel NorthValueLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceLabel SpeedLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceLabel SpeedUnitLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceLabel SpeedValueLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CogLabel != null) {
				CogLabel.Dispose ();
				CogLabel = null;
			}

			if (CogValueCardinalLabel != null) {
				CogValueCardinalLabel.Dispose ();
				CogValueCardinalLabel = null;
			}

			if (CogValueDegreeLabel != null) {
				CogValueDegreeLabel.Dispose ();
				CogValueDegreeLabel = null;
			}

			if (SpeedLabel != null) {
				SpeedLabel.Dispose ();
				SpeedLabel = null;
			}

			if (SpeedValueLabel != null) {
				SpeedValueLabel.Dispose ();
				SpeedValueLabel = null;
			}

			if (SpeedUnitLabel != null) {
				SpeedUnitLabel.Dispose ();
				SpeedUnitLabel = null;
			}

			if (NorthValueLabel != null) {
				NorthValueLabel.Dispose ();
				NorthValueLabel = null;
			}
		}
	}
}
