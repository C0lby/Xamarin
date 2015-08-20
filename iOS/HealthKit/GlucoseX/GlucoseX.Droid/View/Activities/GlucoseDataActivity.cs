
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GlucoseX.Droid
{
	[Activity(Label = "Glucose X", Icon = "@drawable/icon")]
	public class GlucoseDataActivity : Activity
	{
		public static readonly string SelectedDataItemKey = "selected_data_item";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.GlucoseDataActivity);

			var data = GlucoseDataService.Data[Intent.GetIntExtra(SelectedDataItemKey, 0)];

			FragmentManager.BeginTransaction()
				.Add(Resource.Id.glucosx_data_fragment_container, new GlucoseDataFragment (data))
				.Commit();
		}
	}
}