using CSMP.Agent.Logging;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
    public abstract class BaseTask : ITask
    {
        protected readonly AgentConfiguration configuration;
        protected readonly ILogger logger;

        public BaseTask(AgentConfiguration configuration, ILogger logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public abstract Task RunAsync();
    }
}
