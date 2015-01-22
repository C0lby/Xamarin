namespace WatchSpeed
{

	public static class UnitsOfMeasurement
	{
		public enum Keys
		{
			CompassNorth,
			Distance,
			Speed
		}


		public enum CompassNorth
		{
			Magnetic,
			True
		}

		public enum Distance
		{
			Miles,
			Kilometers
		}

		public enum Speed
		{
			MPH,
			KPH,
			Knots
		}
	}
}