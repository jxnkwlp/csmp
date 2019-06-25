using System;
using System.Threading.Tasks;

namespace CSMP.Agent.Windows
{
	class Program
	{
		static void Main(string[] args)
		{
			var task = new AgentTask();

			Task.Run(() => { task.Run(); });

			Console.WriteLine("服务器已启动");
		}
	}
}
