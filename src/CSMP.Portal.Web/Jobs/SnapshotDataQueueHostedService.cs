using CSMP.Portal.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Jobs
{
    public class SnapshotDataQueueHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<SnapshotDataQueueHostedService> _logger;

        public SnapshotDataQueueHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<SnapshotDataQueueHostedService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("The background service is running ....");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var manager = scope.ServiceProvider.GetService<SnapshotDataQueueManager>();

                await manager.ProcessAsync();
            }
        }
    }
}
