using CSMP.Agent.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
    public static class AgentTaskManager
    {
        public static async Task StartAsync()
        {
            var taskList = DependencyService.ResolveAll<ITask>();

            foreach (var task in taskList)
            {
                await task.RunAsync();
            }
        }
    }
}
