using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSMP.Portal.Domains;

namespace CSMP.Portal.Queue
{
    public class SnapshotDataQueue : ISnapshotDataQueue
    {
        private static Queue<Snapshot> _snapshotQueue = new Queue<Snapshot>();

        public Task<IList<Snapshot>> PopAsync(int max = 100)
        {
            IList<Snapshot> result = new List<Snapshot>();

            while (result.Count < max)
            {
                if (_snapshotQueue.TryDequeue(out var item))
                {
                    result.Add(item);
                }
                else
                {
                    break;
                }
            }

            return Task.FromResult(result);
        }

        public Task PushAsync(Snapshot snapshot)
        {
            _snapshotQueue.Enqueue(snapshot);

            return Task.CompletedTask;
        }
    }
}
