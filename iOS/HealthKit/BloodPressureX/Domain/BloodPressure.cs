using System;

namespace BloodPressureX
{
	public class BloodPressure
	{
		public string Unit { get; set; }

		public DateTime Date { get; set; }

		public double Systolic { get; set; }

		public double Diastolic { get; set; }

		public bool WasUserEntered { get; set; }

		public string ValueString {
			get { return string.Format("{0}/{1}", Systolic, Diastolic); }
		}

		public string DateString {
			get { return Date.ToString("g"); }
		}
	}
}