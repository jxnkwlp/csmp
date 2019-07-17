using CSMP.Agent.Executors;
using CSMP.Agent.Logging;
using CSMP.Agent.Model;
using CSMP.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
    public class ServerCommandTask : BaseTask, IServerCommandTask, ITask
    {
        private const string _commandUrlPath = "event/command";

        private static readonly HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

        private readonly ICommandExecutor _commandExecutor;

        public ServerCommandTask(AgentConfiguration configuration, ILogger logger, ICommandExecutor commandExecutor) : base(configuration, logger)
        {
            _commandExecutor = commandExecutor;
        }

        public override async Task RunAsync()
        {
            if (!configuration.Valid())
            {
                logger.Warn("配置不正确！请检查");
                return;
            }

            while (!_disposed)
            {

                string url = configuration.ServerUrl;
                if (!url.EndsWith("/")) url += "/";
                url += _commandUrlPath;

                IList<CommandDefinition> commandDefinitions = null;

                try
                {
                    var response = await _httpClient.GetAsync($"{url}?apitoken={configuration.Token}&identifier={configuration.Identifier}");

                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    commandDefinitions = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<CommandDefinition>>(content);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "获取命令失败");
                }

                if (commandDefinitions == null)
                    continue;

                foreach (var commandDefinition in commandDefinitions)
                {
                    // run command 
                    var executedResult = _commandExecutor.ExecuteAsync(commandDefinition);

                    // callback command result 
                    await ResponseExecutedResultAsync(executedResult);
                }

                // waiting and continue
                Thread.Sleep(100);
            }
             
        }

        private async Task ResponseExecutedResultAsync(ExecuteResultModel model)
        {
            string url = configuration.ServerUrl;
            if (!url.EndsWith("/")) url += "/";
            url += _commandUrlPath;

            // retry 3 times
            await Policy.Handle<Exception>()
                .Retry(3)
                .Execute(async () =>
                {
                    try
                    {
                        var data = new
                        {
                            commandId = model.CommandDefinition.Id,
                            status = (model.Success ? CommandStatus.Complete : CommandStatus.Failed),
                            result = model.ResultData?.ToString(),
                        };

                        var response = await _httpClient.PostAsync($"{url}?apitoken={configuration.Token}&identifier={configuration.Identifier}", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8));

                        response.EnsureSuccessStatusCode();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "反馈命令结果失败");
                        throw;
                    }
                });
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
