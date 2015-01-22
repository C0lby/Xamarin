using System;
using System.IO;
using Foundation;

namespace WatchSpeed
{

	public static class SettingsKeys
	{
		#region About

		public static string VersionNumber = "VersionNumber";

		public static string BuildNumber = "BuildNumber";

		#endregion

		#region Reporting

		public static string UserReferenceKey = "UserReferenceKey";

		#endregion


		#region Units

		public static string UnitCompassNorth = "UnitCompassNorth";

		public static string UseTrueNorth = "UseTrueNorth";

		public static string UnitDistance = "UnitDistance";

		public static string UnitSpeed = "UnitSpeed";

		#endregion
	}

	public static class Settings
	{
		#region Utilities

		public static void RegisterDefaultSettings ()
		{
			var path = Path.Combine (NSBundle.MainBundle.PathForResource ("Settings", "bundle"), "Root.plist");

			using (NSString keyString = new NSString("Key"), defaultString = new NSString("DefaultValue"), preferenceSpecifiers = new NSString("PreferenceSpecifiers"))
			using (var settings = NSDictionary.FromFile (path))
			using (var preferences = (NSArray)settings.ValueForKey (preferenceSpecifiers))
			using (var registrationDictionary = new NSMutableDictionary()) {
				for (nuint i = 0; i < preferences.Count; i++)
					using (var prefSpecification = preferences.GetItem<NSDictionary> (i))
					using (var key = (NSString)prefSpecification.ValueForKey (keyString))
						if (key != null)
							using (var def = prefSpecification.ValueForKey (defaultString))
								if (def != null)
									registrationDictionary.SetValueForKey (def, key);

				NSUserDefaults.StandardUserDefaults.RegisterDefaults (registrationDictionary);
				Synchronize ();
			}
		}

		public static void Synchronize ()
		{
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}

		public static void SetSetting (string key, string value)
		{
			NSUserDefaults.StandardUserDefaults.SetString (value, key);
		}

		public static void SetSetting (string key, bool value)
		{
			NSUserDefaults.StandardUserDefaults.SetBool (value, key);
		}

		public static void SetSetting (string key, int value)
		{
			NSUserDefaults.StandardUserDefaults.SetInt (value, key);
		}

		public static int Int32ForKey (string key)
		{
			return Convert.ToInt32 (NSUserDefaults.StandardUserDefaults.IntForKey (key));
		}

		public static bool BoolForKey (string key)
		{
			return NSUserDefaults.StandardUserDefaults.BoolForKey (key);
		}

		public static string StringForKey (string key)
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey (key);
		}

		#endregion



		#region About

		public static string VersionNumber {
			get {
				return StringForKey (SettingsKeys.VersionNumber);
			}
		}

		public static string BuildNumber {
			get {
				return StringForKey (SettingsKeys.BuildNumber);
			}
		}

		#endregion


		#region Reporting

		public static string UserReferenceKey {
			get {
				var userReferenceKey = StringForKey (SettingsKeys.UserReferenceKey);

				if (string.IsNullOrWhiteSpace (userReferenceKey)) {
					#if DEBUG
					userReferenceKey = "DEBUG";
					#else
					userReferenceKey = Guid.NewGuid ().ToString ("N");
					#endif
					SetSetting (SettingsKeys.UserReferenceKey, userReferenceKey);
				}
				return userReferenceKey;
			}
		}

		#endregion


		#region Units

		public static bool UseTrueNorth {
			get {
				return BoolForKey (SettingsKeys.UseTrueNorth);
			}
			set {
				SetSetting (SettingsKeys.UseTrueNorth, value);
			}
		}

		public static UnitsOfMeasurement.CompassNorth UnitCompassNorth {
			get {
				return (UnitsOfMeasurement.CompassNorth)Int32ForKey (SettingsKeys.UnitCompassNorth);
			}
			set {
				SetSetting (SettingsKeys.UnitCompassNorth, (int)value);
			}
		}

		public static UnitsOfMeasurement.Distance UnitDistance {
			get {
				return (UnitsOfMeasurement.Distance)Int32ForKey (SettingsKeys.UnitDistance);
			}
			set {
				SetSetting (SettingsKeys.UnitDistance, (int)value);
			}
		}

		public static UnitsOfMeasurement.Speed UnitSpeed {
			get {
				return (UnitsOfMeasurement.Speed)Int32ForKey (SettingsKeys.UnitSpeed);
			}
			set {
				SetSetting (SettingsKeys.UnitSpeed, (int)value);
			}
		}

		#endregion
	}
}