using HealthKit;
using Foundation;

namespace BloodPressureX
{
	public static class BloodPressureObjectTypes
	{

		public static HKUnit Unit {
			get { return HKUnit.FromString(Units.mmHg); }
		}

		public static NSSet QuantitySet {
			get { return new NSSet (new [] { QuantitySystolic, QuantityDiastolic }); }
		}

		public static HKQuantityType QuantitySystolic {
			get { return HKObjectType.GetQuantityType(HKQuantityTypeIdentifierKey.BloodPressureSystolic); }
		}

		public static HKQuantityType QuantityDiastolic {
			get { return HKObjectType.GetQuantityType(HKQuantityTypeIdentifierKey.BloodPressureDiastolic); }
		}

		public static HKCorrelationType Correlation {
			get { return HKObjectType.GetCorrelationType(HKCorrelationTypeKey.IdentifierBloodPressure); }
		}
	}
}