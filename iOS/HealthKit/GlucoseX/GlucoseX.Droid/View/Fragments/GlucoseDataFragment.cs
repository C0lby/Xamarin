
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace GlucoseX.Droid
{
	public class GlucoseDataFragment : Fragment
	{

		public GlucoseData Data { get; set; }

		public GlucoseDataFragment ()
		{
			
		}

		public GlucoseDataFragment (GlucoseData data)
		{
			Data = data;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			
			View view = inflater.Inflate(Resource.Layout.GlucoseDataFragment, container, false);

			view.FindViewById<TextView>(Resource.Id.textview_glucose_value).Text = Data?.Value.ToString() ?? "--";
			view.FindViewById<TextView>(Resource.Id.textview_glucose_unit).Text = Data?.Unit ?? "--";
			view.FindViewById<TextView>(Resource.Id.textview_glucose_date).Text = Data?.DateString ?? "--";

			return view;
		}
	}
}