using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Queue
{
    public interface ISnapshotDataQueueManager : IDisposable
    {
        Task ProcessAsync();

    }
}
