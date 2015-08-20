using System;
using HealthKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace GlucoseX.iOS
{
	public static class GlucoseDataExtensions
	{

		public static DateTime NSDateToDateTime (this NSDate date)
		{
			DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime (2001, 1, 1, 0, 0, 0));
			return reference.AddSeconds(date.SecondsSinceReferenceDate);
		}



		public static NSDate DateTimeToNSDate (this DateTime date)
		{
			if (date.Kind == DateTimeKind.Unspecified) {
				date = DateTime.SpecifyKind(date, DateTimeKind.Local);
			}
			return (NSDate)date;
		}



		public static HKQuantitySample ToHKQuantitySample (this GlucoseData data)
		{
			var quantityType = HKObjectType.GetQuantityType(HKQuantityTypeIdentifierKey.BloodGlucose);

			var quantity = HKQuantity.FromQuantity(HKUnit.FromString(data.Unit), data.Value);

			var nsDate = data.Date.DateTimeToNSDate();

			var metadata = new HKMetadata { WasUserEntered = data.UserEntered };

			return HKQuantitySample.FromType(quantityType, quantity, nsDate, nsDate, metadata);
		}



		public static HKQuantitySample[] ToHKQuantitySampleArray (this List<GlucoseData> data)
		{
			return data.Select(d => d.ToHKQuantitySample()).ToArray();
		}


		public static GlucoseData ToGlucoseData (this HKSample sample)
		{
			var quantitySample = sample as HKQuantitySample;

			if (quantitySample != null) {

				var value = quantitySample.Quantity.GetDoubleValue(HKUnit.FromString(Units.mgdL));

				var dateTime = quantitySample.StartDate.NSDateToDateTime();

				var userEntered = quantitySample.Metadata.WasUserEntered ?? false;

				return new GlucoseData {
					Value = value,
					Unit = Units.mgdL,
					Date = dateTime,
					UserEntered = userEntered
				};
			}

			return null;
		}


		public static List<GlucoseData> ToGlucoseDataList (this HKSample[] sample)
		{
			return sample.Select(s => s.ToGlucoseData()).ToList();
		}
	}
}