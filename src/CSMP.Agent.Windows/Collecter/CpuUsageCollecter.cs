using CSMP.Agent.Collecter;
using System;
using System.Management;

namespace CSMP.Agent.Windows.Collecter
{
	public class CpuUsageCollecter : ICollecter<CollectionResult>
	{
		public string Name => "cpu";

		public CollectionResult Collect()
		{
			ManagementScope scope = new ManagementScope("\\root\\cimv2");
			scope.Connect();
			ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

			ManagementObjectCollection queryCollection = searcher.Get();

			double result = 0;

			foreach (ManagementObject obj in queryCollection)
			{
				var usage = obj["PercentProcessorTime"];
				var name = obj["Name"];
				Console.WriteLine(name + " : " + usage);

				if (name.ToString() == "_Total")
					double.TryParse(usage.ToString(), out result);
			}

			return new CollectionResult() { CollectionTime = DateTime.Now, Value = result };
		}
	}
}
