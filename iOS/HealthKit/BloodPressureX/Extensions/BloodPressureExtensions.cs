using System;
using HealthKit;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace BloodPressureX
{
	public static class BloodPressureExtensions
	{

		public static HKUnit GetHKUnit (this BloodPressure bp)
		{
			return string.IsNullOrEmpty(bp.Unit) ? BloodPressureObjectTypes.Unit : HKUnit.FromString(bp.Unit);
		}


		public static HKCorrelation ToHKCorrelation (this BloodPressure bp)
		{
			var nsDate = bp.Date.DateTimeToNSDate();

			var metadata = new HKMetadata { WasUserEntered = bp.WasUserEntered };

			var systolicQuantity = HKQuantity.FromQuantity(HKUnit.FromString(bp.Unit), bp.Systolic);
			var systolicQuantitySample = HKQuantitySample.FromType(BloodPressureObjectTypes.QuantitySystolic, systolicQuantity, nsDate, nsDate, metadata);

			var diastolicQuantity = HKQuantity.FromQuantity(HKUnit.FromString(bp.Unit), bp.Diastolic);
			var diastolicQuantitySample = HKQuantitySample.FromType(BloodPressureObjectTypes.QuantityDiastolic, diastolicQuantity, nsDate, nsDate, metadata);

			var bloodPressureDataSet = new NSSet (new [] { systolicQuantitySample, diastolicQuantitySample });

			var bloodPressureCorrelation = HKCorrelation.Create(BloodPressureObjectTypes.Correlation, nsDate, nsDate, bloodPressureDataSet, metadata);

			return bloodPressureCorrelation;
		}


		public static HKCorrelation[] ToHKCorrelationArray (this List<BloodPressure> bp)
		{
			return bp.Select(d => d.ToHKCorrelation()).ToArray();
		}



		public static BloodPressure ToBloodPressure (this HKSample sample)
		{
			var correlation = sample as HKCorrelation;

			if (correlation != null) {

				var systolicQuantity = correlation.Objects.FirstOrDefault(o => 
					((HKQuantitySample)o).QuantityType.Identifier == BloodPressureObjectTypes.QuantitySystolic.Identifier) as HKQuantitySample;
				
				var systolicQuantitySample = systolicQuantity?.Quantity.GetDoubleValue(BloodPressureObjectTypes.Unit) ?? 0;


				var diastolicQuantity = correlation.Objects.FirstOrDefault(o => 
					((HKQuantitySample)o).QuantityType.Identifier == BloodPressureObjectTypes.QuantityDiastolic.Identifier) as HKQuantitySample;

				var diastolicQuantitySample = diastolicQuantity?.Quantity.GetDoubleValue(BloodPressureObjectTypes.Unit) ?? 0;


				var dateTime = correlation.StartDate.NSDateToDateTime();

				var wasUserEntered = correlation.Metadata.WasUserEntered ?? false;


				return new BloodPressure {
					Unit = Units.mmHg,
					Date = dateTime,
					Systolic = systolicQuantitySample,
					Diastolic = diastolicQuantitySample,
					WasUserEntered = wasUserEntered
				};
			}

			return null;
		}


		public static List<BloodPressure> ToBloodPressureList (this HKSample[] sample)
		{
			return sample.Select(s => s.ToBloodPressure()).ToList();
		}
	}
}