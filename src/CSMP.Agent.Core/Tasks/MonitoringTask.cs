using CSMP.Agent.Collecter;
using CSMP.Agent.Logging;
using CSMP.Agent.Queue;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
    public class MonitoringTask : BaseTask, IMonitoringTask, ITask
    {
        private readonly IMonitoringQueue _monitoringQueue;

        public MonitoringTask(AgentConfiguration configuration, ILogger logger, IMonitoringQueue monitoringQueue) : base(configuration, logger)
        {
            _monitoringQueue = monitoringQueue;
        }

        public override Task RunAsync()
        {
            while (!_disposed)
            {
                try
                {
                    var list = CollecterManager.GetAllCollections();

                    if (list != null && list.Count > 0)
                    {
                        _monitoringQueue.PushAsync(list);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "收集数据失败");
                }

                Thread.Sleep(1000);
            }

            return Task.CompletedTask;
        }

        private bool _disposed = false;

        public override void Dispose()
        {
            base.Dispose();
            if (!_disposed)
                _disposed = true;
        }
    }
}
