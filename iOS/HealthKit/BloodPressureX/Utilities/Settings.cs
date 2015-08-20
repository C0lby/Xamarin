using System;
using System.IO;
using Foundation;
using UIKit;

namespace BloodPressureX
{
	static class SettingsKeys
	{
		public static string VersionNumber = "VersionNumber";
		public static string BuildNumber = "BuildNumber";
		public static string UserReferenceKey = "UserReferenceKey";
		public static string FirstLaunch = "FirstLaunch";
	}


	public static class Settings
	{
		#region Utilities

		public static void RegisterDefaultSettings ()
		{
			var path = Path.Combine(NSBundle.MainBundle.PathForResource("Settings", "bundle"), "Root.plist");

			using (NSString keyString = new NSString ("Key"), defaultString = new NSString ("DefaultValue"), preferenceSpecifiers = new NSString ("PreferenceSpecifiers"))
			using (var settings = NSDictionary.FromFile(path))
			using (var preferences = (NSArray)settings.ValueForKey(preferenceSpecifiers))
			using (var registrationDictionary = new NSMutableDictionary ()) {
				for (nuint i = 0; i < preferences.Count; i++)
					using (var prefSpecification = preferences.GetItem<NSDictionary>(i))
					using (var key = (NSString)prefSpecification.ValueForKey(keyString))
						if (key != null)
							using (var def = prefSpecification.ValueForKey(defaultString))
								if (def != null)
									registrationDictionary.SetValueForKey(def, key);

				NSUserDefaults.StandardUserDefaults.RegisterDefaults(registrationDictionary);
				Synchronize();
			}
		}

		public static void Synchronize ()
		{
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}

		public static void SetSetting (string key, string value)
		{
			NSUserDefaults.StandardUserDefaults.SetString(value, key);
		}

		public static void SetSetting (string key, bool value)
		{
			NSUserDefaults.StandardUserDefaults.SetBool(value, key);
		}

		public static void SetSetting (string key, int value)
		{
			NSUserDefaults.StandardUserDefaults.SetInt(value, key);
		}

		public static int Int32ForKey (string key)
		{
			return Convert.ToInt32(NSUserDefaults.StandardUserDefaults.IntForKey(key));
		}

		public static bool BoolForKey (string key)
		{
			return NSUserDefaults.StandardUserDefaults.BoolForKey(key);
		}

		public static string StringForKey (string key)
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey(key);
		}

		#endregion


		#region About

		public static string VersionNumber {
			get { return StringForKey(SettingsKeys.VersionNumber); }
		}

		public static string BuildNumber {
			get { return StringForKey(SettingsKeys.BuildNumber); }
		}

		public static string VersionBuildString {
			get { return string.Format("v{0} b{1}", VersionNumber, BuildNumber); }
		}

		#endregion


		#region Config

		public static bool FirstLaunch {
			get {
				// this is actually false if it's the first time the app is launched
				var firstL = !BoolForKey(SettingsKeys.FirstLaunch);

				if (firstL) {
					SetSetting(SettingsKeys.FirstLaunch, true);

					// set defaults here if nessesary
				}

				return firstL;
			}
		}

		#endregion



		#region Reporting

		public static string UserReferenceKey {
			get {
				var key = StringForKey(SettingsKeys.UserReferenceKey);

				if (string.IsNullOrEmpty(key)) {
					key = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
					SetSetting(SettingsKeys.UserReferenceKey, key);
				}

				return key;
			}
		}

		#endregion
	}
}