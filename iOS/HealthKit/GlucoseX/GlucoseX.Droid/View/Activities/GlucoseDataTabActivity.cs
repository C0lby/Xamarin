
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
	[Activity(Label = "Glucose X", MainLauncher = true, Icon = "@drawable/icon")]		
	public class GlucoseDataTabActivity : Activity
	{
		List<Fragment> fragments = new List<Fragment> {
			new GlucoseDataFragment (),
			new HistoryListFragment ()
		};

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.GlucoseDataActivity);

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			var recentTab = ActionBar.NewTab().SetText("Most Recent");
			recentTab.TabSelected += HandleTabSelected;
			ActionBar.AddTab(recentTab);

			var historyTab = ActionBar.NewTab().SetText("History");
			historyTab.TabSelected += HandleTabSelected;
			ActionBar.AddTab(historyTab);
		}

		void HandleTabSelected (object sender, ActionBar.TabEventArgs tabEventArgs)
		{
			var tab = (ActionBar.Tab)sender;

			var frag = fragments[tab.Position];

			tabEventArgs.FragmentTransaction.Replace(Resource.Id.glucosx_data_fragment_container, frag);
		}
	}
}