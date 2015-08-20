using System;
using System.Collections.Generic;

namespace GlucoseX
{
	public static class Units
	{
		public static string mgdL = "mg/dL";
	}

	public class GlucoseData
	{
		public double Value { get; set; }

		public string Unit { get; set; }

		public DateTime Date { get; set; }

		public bool UserEntered { get; set; }

		public string ValueString {
			get { return string.Format("{0}{1}", Value, Unit); }
		}

		public string DateString {
			get { return Date.ToString("g"); }
		}
	}
}