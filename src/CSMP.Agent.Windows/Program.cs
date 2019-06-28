using CSMP.Agent.Dependency;
using CSMP.Agent.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Management;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Diagnostics;

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



			//ManagementScope scope = new ManagementScope("\\root\\cimv2");
			//scope.Connect();
			////ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
			//ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
			//ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

			//while (true)
			//{

			//	ManagementObjectCollection queryCollection = searcher.Get();

			//	foreach (ManagementObject obj in queryCollection)
			//	{
			//		// Display the remote computer information
			//		//Console.WriteLine("Computer Name     : {0}", m["csname"]);
			//		//Console.WriteLine("Windows Directory : {0}", m["WindowsDirectory"]);
			//		//Console.WriteLine("Operating System  : {0}", m["Caption"]);
			//		//Console.WriteLine("Version           : {0}", m["Version"]);
			//		//Console.WriteLine("Manufacturer      : {0}", m["Manufacturer"]);

			//		//var usage = obj["PercentProcessorTime"];
			//		//var name = obj["Name"];
			//		//Console.WriteLine(name + " : " + usage);

			//		foreach (var item in obj.Properties)
			//		{
			//			Console.WriteLine($"{item.Name}:   {item.Value}");
			//		}
			//	}


			//	Thread.Sleep(2000);
			//}


			//return;


			var agentConfig = new AgentConfiguration();
			configuration.Bind(agentConfig);

			DependencyService.Register(() => agentConfig);
			DependencyService.Register<IAgentTask, AgentTask>();
			DependencyService.Register<IHeartbeatTask, HeartbeatTask>();


			var task = DependencyService.Resolve<IAgentTask>();

			Task.Run(() => { task.Run(); });

			Console.WriteLine("服务器已启动");

		}
	}
}
