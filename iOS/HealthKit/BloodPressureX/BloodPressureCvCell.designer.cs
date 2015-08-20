// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace BloodPressureX
{
	[Register ("BloodPressureCvCell")]
	partial class BloodPressureCvCell
	{
		[Outlet]
		UIKit.UILabel BloodPressureDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel BloodPressureValueLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BloodPressureValueLabel != null) {
				BloodPressureValueLabel.Dispose ();
				BloodPressureValueLabel = null;
			}

			if (BloodPressureDateLabel != null) {
				BloodPressureDateLabel.Dispose ();
				BloodPressureDateLabel = null;
			}
		}
	}
}
