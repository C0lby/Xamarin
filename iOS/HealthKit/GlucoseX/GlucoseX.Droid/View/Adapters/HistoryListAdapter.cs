using System;
using Android.Widget;
using Android.Views;
using Android.App;

namespace GlucoseX.Droid
{
	public class GlucoseDataItemHolder : Java.Lang.Object
	{
		public TextView Title { get; set; }

		public TextView Subtitle { get; set; }
	}


	public class HistoryListAdapter : BaseAdapter<GlucoseData>
	{

		Activity context;

		public HistoryListAdapter (Activity context)
		{
			this.context = context;
		}


		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return 0;
		}


		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			GlucoseDataItemHolder holder;

			View cell = convertView;

			if (cell == null) {
				
				cell = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

				holder = new GlucoseDataItemHolder {
					Title = cell.FindViewById<TextView>(Android.Resource.Id.Text1),
					Subtitle = cell.FindViewById<TextView>(Android.Resource.Id.Text2)
				};

				cell.Tag = holder;
			
			} else {
				
				holder = (GlucoseDataItemHolder)cell.Tag;
			}

			holder.Title.Text = GlucoseDataService.Data[position].DateString;
			holder.Subtitle.Text = GlucoseDataService.Data[position].ValueString;

			return cell;
		}



		public override int Count {
			get {
				return GlucoseDataService.Data.Count;
			}
		}

		#endregion


		#region implemented abstract members of BaseAdapter

		public override GlucoseData this [int index] {
			get {
				return GlucoseDataService.Data[index];
			}
		}

		#endregion
	}
}