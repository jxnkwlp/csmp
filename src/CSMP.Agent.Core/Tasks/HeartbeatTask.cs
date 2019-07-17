using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSMP.Agent.Logging;
using CSMP.Agent.Queue;

namespace CSMP.Agent.Tasks
{
    /// <summary>
    ///  心跳任务
    ///  5秒一次
    ///  发送内容为 服务器的 状态信息，比如，cpu, 内存，网卡 等，
    /// </summary>
    public class HeartbeatTask : BaseTask, IHeartbeatTask, ITask
    {
        const string urlPath = "event/heartbeat";

        private static readonly HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

        private bool canRun = false;
        private readonly IMonitoringQueue _monitoringQueue;

        public HeartbeatTask(AgentConfiguration configuration, ILogger logger, IMonitoringQueue monitoringQueue) : base(configuration, logger)
        {
            _monitoringQueue = monitoringQueue;
        }

        public override async Task RunAsync()
        {
            if (!configuration.Valid())
            {
                logger.Warn("配置不正确！请检查");
                return;
            }

            string url = configuration.ServerUrl;
            if (!url.EndsWith("/")) url += "/";
            url += urlPath;

            while (!_disposed)
            {
                try
                {
                    var snapshotList = _monitoringQueue.PopAsync();

                    var data = new { snapshots = snapshotList };

                    var response = await _httpClient.PostAsync($"{url}?apitoken={configuration.Token}&identifier={configuration.Identifier}", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8));

                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "发送心跳数据失败");
                }

                Thread.Sleep(5000);
            }

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
