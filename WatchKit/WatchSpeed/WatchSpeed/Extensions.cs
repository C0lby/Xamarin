using System;

namespace WatchSpeed
{

	public static class Extensions
	{
		/*
		 * UoM Extensions
		 */

		/// <summary>
		/// Converts length value from kilometers to miles.
		/// </summary>
		/// <returns>The length value in miles.</returns>
		/// <param name="k">The length value in kilometers.</param>
		public static double KilometersToMiles (this double k)
		{
			return k * 0.621371;
		}

		/// <summary>
		/// Converts Speed value from Meters per Second to Miles per Hour.
		/// </summary>
		/// <returns>The Speed in Miles per Hour.</returns>
		/// <param name="mps">The Speed in Meters per Second.</param>
		public static double MpsToMph (this double mps)
		{
			return mps.MpsToKph ().KphToMph ();
		}

		/// <summary>
		/// Converts Speed value from Meters per Second to Kilometers per Hour.
		/// </summary>
		/// <returns>The Speed in Kilometers per Hour.</returns>
		/// <param name="mps">The Speed in Meters per Second.</param>
		public static double MpsToKph (this double mps)
		{
			return mps * 3.6;
		}

		/// <summary>
		/// Converts Speed value from Meters per Second to Knots.
		/// </summary>
		/// <returns>The Speed in Knots.</returns>
		/// <param name="mps">The Speed in Meters per Second.</param>
		public static double MpsToKnots (this double mps)
		{
			return mps * 1.943844;
		}

		/// <summary>
		/// Converts Speed value from Kilometers per Hour to Miles per Hour.
		/// </summary>
		/// <returns>The Speed in Miles per Hour.</returns>
		/// <param name="kph">The Speed in Kilometers per Hour.</param>
		public static double KphToMph (this double kph)
		{
			return kph * 0.621371;
		}

		/// <summary>
		/// Converts Speed value from Kilometers per Hour to Knots.
		/// </summary>
		/// <returns>The Speed in Knots.</returns>
		/// <param name="kph">The Speed in Kilometers per Hour.</param>
		public static double KphToKnots (this double kph)
		{
			return kph * 0.539957;
		}

		/// <summary>
		/// Converts Degrees to Radians
		/// </summary>
		/// <returns>Radians.</returns>
		/// <param name="d">Degrees</param>
		public static double ToRadians (this double d)
		{
			return d * (Math.PI / 180);
		}

		/// <summary>
		/// Converts Degrees to Radians
		/// </summary>
		/// <returns>Radians.</returns>
		/// <param name="d">Degrees</param>
		public static double ToRadians (this float d)
		{
			return d * (Math.PI / 180);
		}

		/// <summary>
		/// Converts Degrees to Radians
		/// </summary>
		/// <returns>Radians.</returns>
		/// <param name="d">Degrees</param>
		public static double ToRadians (this int d)
		{
			return d * (Math.PI / 180);
		}

		/// <summary>
		/// Converts value from Feet to Meters.
		/// </summary>
		/// <returns>The value in Meters.</returns>
		/// <param name="f">The value in Feet</param>
		public static double FeetToMeters (this double f)
		{
			return f / 3.28084;
		}

		/// <summary>
		/// Converts value from Meters to Feet.
		/// </summary>
		/// <returns>The value in Feet.</returns>
		/// <param name="m">The value in Meters</param>
		public static double MetersToFeet (this double m)
		{
			return m * 3.28084;
		}



		/*
		 * String Extensions
		 */

		public static string ToDegreeString (this string s)
		{
			return String.Format ("{0}°", s);
		}

		public static string ToDegreeString (this double s)
		{
			return Math.Round (s).ToString ().ToDegreeString ();
		}


		/*
		 * Direction Extensions
		 */

		public static string[] Cardinal = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };

		public static string ToDirectionString (this double h)
		{
			int d = 360 / Cardinal.Length;
			int i = (int)((h / d) + 0.5);
			i = i % Cardinal.Length;
			return Cardinal[i];
		}

		public static string ToDirectionString (this int h)
		{
			int d = 360 / Cardinal.Length;
			int i = (int)((h / d) + 0.5);
			i = i % Cardinal.Length;
			return Cardinal[i];
		}

	}
}