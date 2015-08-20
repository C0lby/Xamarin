using System;
using HealthKit;
using Foundation;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace GlucoseX.iOS
{
	public static class HealthKitProvider
	{
		static readonly HKHealthStore healthKitStore = new HKHealthStore ();

		static NSSet glucoseQuantityTypeSet {
			get { return new NSSet (new [] { glucoseQuantityType }); }
		}

		static HKQuantityType glucoseQuantityType {
			get { return HKObjectType.GetQuantityType(HKQuantityTypeIdentifierKey.BloodGlucose); }
		}

		static NSSortDescriptor[] queryDescriptors {
			get { return new [] { new NSSortDescriptor (HKSample.SortIdentifierStartDate, false) }; }
		}


		public static Task<Tuple<bool, NSError>> ValidateAuthorizationAsync ()
		{
			return healthKitStore.RequestAuthorizationToShareAsync(glucoseQuantityTypeSet, glucoseQuantityTypeSet);
		}


		public async static Task SaveGlucoseDataToHealthAppAsync (GlucoseData data)
		{
			await healthKitStore.SaveObjectAsync(data.ToHKQuantitySample());
		}


		public async static Task SaveGlucoseDataToHealthAppAsync (List<GlucoseData> data)
		{
			await healthKitStore.SaveObjectsAsync(data.ToHKQuantitySampleArray());
		}


		public static Task<List<GlucoseData>> RetrieveGlucoseDataFromHealthAppAsync ()
		{
			var tcs = new TaskCompletionSource<List<GlucoseData>> ();

			var sampleQuery = new HKSampleQuery (glucoseQuantityType, null, 2000, queryDescriptors, (query, results, error) => {

				if (error != null) Console.WriteLine(error.LocalizedDescription);

				tcs.SetResult(results?.ToGlucoseDataList());
			});

			healthKitStore.ExecuteQuery(sampleQuery);

			return tcs.Task;
		}
	}
}