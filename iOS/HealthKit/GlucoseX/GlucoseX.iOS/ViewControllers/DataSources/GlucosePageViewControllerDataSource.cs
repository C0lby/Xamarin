using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace GlucoseX.iOS
{
	public class GlucosePageViewControllerDataSource : UIPageViewControllerDataSource
	{
		readonly List<GlucoseDataViewController> Controllers = new List<GlucoseDataViewController> ();

		GlucoseDataViewController viewControllerForDataItem (UIPageViewController pageViewController, GlucoseData data)
		{
			if (pageViewController == null || data == null) return null;

			var controller = Controllers.FirstOrDefault(c => c.Data == data);

			if (controller == null) {

				controller = pageViewController.Storyboard.Instantiate<GlucoseDataViewController>();

				controller.Data = data;

				Controllers.Add(controller);
			}

			return controller;
		}


		public GlucosePageViewControllerDataSource (GlucoseDataViewController initialViewController)
		{
			Controllers.Add(initialViewController);
		}

		public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var glucoseDataViewController = referenceViewController as GlucoseDataViewController;

			return viewControllerForDataItem(pageViewController, glucoseDataViewController?.Data.GetPreviousDataItem());
		}


		public override UIViewController GetNextViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var glucoseDataViewController = referenceViewController as GlucoseDataViewController;

			return viewControllerForDataItem(pageViewController, glucoseDataViewController?.Data.GetNextDataItem());
		}
	}
}