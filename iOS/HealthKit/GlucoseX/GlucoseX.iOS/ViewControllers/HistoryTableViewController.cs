using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace GlucoseX.iOS
{
	public partial class HistoryTableViewController : UITableViewController
	{
		const string cellId = "HistoryTableViewCell";

		public HistoryTableViewController (IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			// Data = GlucoseDataService.CreateRandomGlucoseData();
		}



		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}



		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return GlucoseDataService.Data?.Count ?? 0;
		}



		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(cellId, indexPath);

			var data = GlucoseDataService.Data[indexPath.Row];

			cell.TextLabel.Text = data.DateString;

			cell.DetailTextLabel.Text = data.ValueString;

			return cell;
		}



		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var glucoseDataViewController = Storyboard.Instantiate<GlucoseDataViewController>();

			glucoseDataViewController.Data = GlucoseDataService.Data[indexPath.Row];

			NavigationController.PushViewController(glucoseDataViewController, true);
		}



		async partial void RefreshControlValueChanged (UIRefreshControl sender)
		{
			GlucoseDataService.Data = await HealthKitProvider.RetrieveGlucoseDataFromHealthAppAsync();

			TableView.ReloadData();

			sender.EndRefreshing();
		}
	}
}