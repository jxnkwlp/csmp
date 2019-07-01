using CSMP.Agent.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
    public static class AgentTaskManager
    {
        public static void Start()
        {
            var taskList = DependencyService.ResolveAll<ITask>();

            foreach (var task in taskList)
            {
                Task.Run(() => task.RunAsync());
            }
        }
    }
}
