using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSMP.Agent.Collecter;

namespace CSMP.Agent.Queue
{
    public class MemoryMonitoringQueue : IMonitoringQueue
    {
        public Task<IList<CollectionResult>> PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(IList<CollectionResult> result)
        {
            throw new NotImplementedException();
        }
    }
}
