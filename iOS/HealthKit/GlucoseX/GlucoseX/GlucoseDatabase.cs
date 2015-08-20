using System;
using System.Collections.Generic;

namespace GlucoseX
{
	public class GlucoseDatabase
	{
		public const string mgdL = "mg/dL";

		public static List<GlucoseData> AllData = new List<GlucoseData> {
			new GlucoseData {
				Unit = mgdL,
				UserEntered = false
			}
		};
	}
}

