using System;

namespace WatchSpeed
{

	public static class UomManager
	{
		public static double GetSpeedInPreferredUnit (double speedAsMps)
		{
			switch (Settings.UnitSpeed) {
				case UnitsOfMeasurement.Speed.MPH:
					return Math.Round (speedAsMps.MpsToMph ());
				case UnitsOfMeasurement.Speed.KPH:
					return Math.Round (speedAsMps.MpsToKph ());
				case UnitsOfMeasurement.Speed.Knots:
					return Math.Round (speedAsMps.MpsToKnots ());
				default:
					return Math.Round (speedAsMps.MpsToMph ());
			}
		}

		public static string GetSpeedPreferredUnit ()
		{
			switch (Settings.UnitSpeed) {
				case UnitsOfMeasurement.Speed.MPH:
					return "mph";
				case UnitsOfMeasurement.Speed.KPH:
					return "kph";
				case UnitsOfMeasurement.Speed.Knots:
					return "knots";
				default:
					return "mph";
			}
		}


		public static string GetTrueNorthPrefferedUnit ()
		{
			return Settings.UseTrueNorth ? "True North" : "Magnetic North";
		}
	}
}