using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSMP.Agent.Collecter;

namespace CSMP.Agent.Queue
{
    public class MemoryMonitoringQueue : IMonitoringQueue
    {
        protected static Queue<CollectionResult> _queue = new Queue<CollectionResult>();

        public MemoryMonitoringQueue()
        {
        }

        public Task<List<CollectionResult>> PopAsync()
        {
            var result = new List<CollectionResult>();

            while (true)
            {
                if (_queue.TryDequeue(out var item))
                {
                    result.Add(item);
                }
                else
                    break;
            }

            return Task.FromResult(result);
        }

        public Task PushAsync(IList<CollectionResult> result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            foreach (var item in result)
            {
                _queue.Enqueue(item);
            }

            return Task.CompletedTask;
        }
    }
}
