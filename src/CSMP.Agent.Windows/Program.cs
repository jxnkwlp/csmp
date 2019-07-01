using CSMP.Agent.Dependency;
using CSMP.Agent.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Management;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.IO;
using CSMP.Agent.Logging;
using CSMP.Agent.Collecter;

namespace CSMP.Agent.Windows
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json", true, false)
                .Build();

            // TODO 向系统写入一个全部标志，避免重复配置，或者是拷贝配置

            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")))
            {
                StartupToRegister();

                return;
            }

            if (args != null && args.Contains("--config"))
            {
                StartupToRegister();

                return;
            }

            var agentConfig = new AgentConfiguration();
            configuration.Bind(agentConfig);

            DependencyService.Register(() => agentConfig);
            DependencyService.Register<ILogger, NullLogger>();
            DependencyService.RegisterTypes<ITask>();
            DependencyService.RegisterTypes(typeof(ICollecter<>));

            AgentTaskManager.Start();

            Console.WriteLine("Agent服务已启动");
        }

        static void StartupToRegister()
        {
            Console.Write("Agent服务未配置,是否开始配置? Y/n: ");

            var enterKey = Console.ReadKey(true);

            Console.Write(enterKey.KeyChar);

            if (enterKey.Key == ConsoleKey.N)
            {
                return;
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");

            // GOTO config startup

            new AgentResiter().Run();
        }
    }
}
