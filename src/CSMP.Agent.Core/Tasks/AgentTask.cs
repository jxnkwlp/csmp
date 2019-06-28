using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
	public class AgentTask : IAgentTask
	{
		const string urlPath = "event/command";

		static HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

		public virtual void Run()
		{

		}

		private Task RunTaskAsync() {

		}
	}
}
