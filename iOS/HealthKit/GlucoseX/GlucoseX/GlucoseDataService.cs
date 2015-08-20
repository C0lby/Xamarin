using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GlucoseX
{
	public static class GlucoseDataService
	{
		public static List<GlucoseData> Data = new List<GlucoseData> ();

		public static List<GlucoseData> GenerateRandomGlucoseData ()
		{
			var data = new List<GlucoseData> ();

			var random = new Random (); // random number generator

			var date = DateTime.Now; // get the current date and time

			for (int i = 0; i < 500; i++) { // create 500 records

				data.Add(new GlucoseData {
					Value = random.Next(80, 120), // random value for glucose level between 80 and 120
					Unit = Units.mgdL,
					Date = date,
					UserEntered = false
				});

				date = date.Subtract(TimeSpan.FromMinutes(random.Next(45, 75))); // random time between 45 and 75 mins
			}

			return data;
		}


		public static GlucoseData GetPreviousDataItem (this GlucoseData data)
		{
			return Data.LastOrDefault(d => d.Date > data.Date);
		}


		public static GlucoseData GetNextDataItem (this GlucoseData data)
		{
			return Data.FirstOrDefault(d => d.Date < data.Date);
		}
	}
}