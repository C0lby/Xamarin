using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using HealthKit;

namespace BloodPressureX
{
	public static class HealthKit
	{
		static readonly HKHealthStore healthKitStore = new HKHealthStore ();


		static NSPredicate queryPredicate {
			get { return NSPredicate.FromValue(true); }
		}


		//		static NSDictionary samplePredicates {
		//			get { return new NSDictionary (); }
		//		}


		public static Task<Tuple<bool, NSError>> ValidateAuthorizationAsync ()
		{
			return healthKitStore.RequestAuthorizationToShareAsync(BloodPressureObjectTypes.QuantitySet, BloodPressureObjectTypes.QuantitySet);
		}


		public async static Task SaveBloodPressureDataToHealthAppAsync (BloodPressure data)
		{
			await healthKitStore.SaveObjectAsync(data.ToHKCorrelation());
		}


		public async static Task SaveBloodPressureDataToHealthAppAsync (List<BloodPressure> data)
		{
			await healthKitStore.SaveObjectsAsync(data.ToHKCorrelationArray());
		}


		public static Task<List<BloodPressure>> RetrieveBloodPressureDataFromHealthAppAsync ()
		{
			var tcs = new TaskCompletionSource<List<BloodPressure>> ();


			NSPredicate allPredicate = HKQuery.GetPredicateForQuantitySamples(NSPredicateOperatorType.GreaterThanOrEqualTo, HKQuantity.FromQuantity(BloodPressureObjectTypes.Unit, 0));

			var samplePredicates = new NSDictionary (BloodPressureObjectTypes.QuantitySystolic, allPredicate, BloodPressureObjectTypes.QuantityDiastolic, allPredicate);

			var correlationQuery = new HKCorrelationQuery (BloodPressureObjectTypes.Correlation, NSPredicate.FromValue(true), samplePredicates, (query, correlations, error) => {

				if (error != null) Console.WriteLine(error.LocalizedDescription);

				tcs.SetResult(correlations?.ToBloodPressureList());

			});

			healthKitStore.ExecuteQuery(correlationQuery);

			return tcs.Task;
		}
	}
}