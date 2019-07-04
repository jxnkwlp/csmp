using CSMP.Portal.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSMP.Portal.Queue
{
    public class SnapshotDataQueueManager : ISnapshotDataQueueManager
    {
        private readonly ISnapshotDataStore _snapshotDataStore;
        private readonly ISnapshotDataQueue _snapshotDataQueue;
        private readonly ILogger<SnapshotDataQueueManager> _logger;

        public SnapshotDataQueueManager(ISnapshotDataStore snapshotDataStore, ISnapshotDataQueue snapshotDataQueue, ILogger<SnapshotDataQueueManager> logger)
        {
            _snapshotDataStore = snapshotDataStore;
            _snapshotDataQueue = snapshotDataQueue;
            _logger = logger;
        }

        public async Task ProcessAsync()
        {
            while (!_disposed)
            {
                var list = await _snapshotDataQueue.PopAsync(10);

                try
                {
                    await _snapshotDataStore.InsertAsync(list);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "写入数据失败");
                }

                Thread.Sleep(100);
            }
        }

        private bool _disposed;

        public void Dispose()
        {
            if (!_disposed)
                _disposed = true;
        }
    }
}
