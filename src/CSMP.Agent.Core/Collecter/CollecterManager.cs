using CSMP.Agent.Dependency;
using CSMP.Agent.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSMP.Agent.Collecter
{
    public class CollecterManager
    {
        public static IList<CollectionResult> GetAllCollections()
        {
            // TODO ResolveAll for generic-interface
            //var list = DependencyService.ResolveAll(typeof(ICollecter<>));

            var memoryUsageCollecter = DependencyService.ResolveAll<IMemoryUsageCollecter>().FirstOrDefault();
            var diskStorageUsageCollecter = DependencyService.ResolveAll<IDiskStorageUsageCollecter>().FirstOrDefault();
            var cpuUsageCollecter = DependencyService.ResolveAll<ICpuUsageCollecter>().FirstOrDefault();

            var logger = DependencyService.Resolve<ILogger>();

            var result = new List<CollectionResult>();

            try
            {
                if (memoryUsageCollecter != null)
                    result.Add(memoryUsageCollecter.GetSnapshot());

                if (diskStorageUsageCollecter != null)
                    result.Add(diskStorageUsageCollecter.GetSnapshot());

                if (cpuUsageCollecter != null)
                    result.Add(cpuUsageCollecter.GetSnapshot());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "采集数据失败");
            }

            return result;
        }
    }
}
