using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Collecter
{
	public class DiskStorageUsage : CollectionResult
	{
		public IList<DiskStorageInfo> DiskStorages { get; set; }
	}

	public class DiskStorageInfo
	{
		public string DriveName { get; set; }
		public double Total { get; set; }
		public double Free { get; set; }
	}
}
