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
	[Register ("GlucoseDataNewEntryTableViewController")]
	partial class GlucoseDataNewEntryTableViewController
	{
		[Outlet]
		UIKit.UIBarButtonItem AddButton { get; set; }

		[Outlet]
		UIKit.UITextField DataFieldDate { get; set; }

		[Outlet]
		UIKit.UITextField DataFieldGlucose { get; set; }

		[Outlet]
		UIKit.UITextField DataFieldTime { get; set; }

		[Action ("AddButtonClicked:")]
		partial void AddButtonClicked (Foundation.NSObject sender);

		[Action ("CancelButtonClicked:")]
		partial void CancelButtonClicked (Foundation.NSObject sender);

		[Action ("DatePickerValueChanged:")]
		partial void DatePickerValueChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}

			if (DataFieldDate != null) {
				DataFieldDate.Dispose ();
				DataFieldDate = null;
			}

			if (DataFieldGlucose != null) {
				DataFieldGlucose.Dispose ();
				DataFieldGlucose = null;
			}

			if (DataFieldTime != null) {
				DataFieldTime.Dispose ();
				DataFieldTime = null;
			}
		}
	}
}
