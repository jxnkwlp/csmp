using CSMP.Agent.Collecter;
using System;

namespace CSMP.Agent.Windows.Collecter
{
    public class DiskStorageUsageCollecter : IDiskStorageUsageCollecter
    {
        public string Name => "disk";

        public DiskStorageUsage GetSnapshot()
        {
            // TODO 
            return new DiskStorageUsage();
        }
    }
}
