// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace GlucoseX.iOS
{
	[Register ("GlucoseDataViewController")]
	partial class GlucoseDataViewController
	{
		[Outlet]
		UIKit.UILabel GlucoseDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel GlucoseUnitLabel { get; set; }

		[Outlet]
		UIKit.UILabel GlucoseValueLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GlucoseValueLabel != null) {
				GlucoseValueLabel.Dispose ();
				GlucoseValueLabel = null;
			}

			if (GlucoseUnitLabel != null) {
				GlucoseUnitLabel.Dispose ();
				GlucoseUnitLabel = null;
			}

			if (GlucoseDateLabel != null) {
				GlucoseDateLabel.Dispose ();
				GlucoseDateLabel = null;
			}
		}
	}
}
