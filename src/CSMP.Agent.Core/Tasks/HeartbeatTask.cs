using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSMP.Agent.Tasks
{
	/// <summary>
	///  心跳任务
	///  5秒一次
	///  发送内容为 服务器的 状态信息，比如，cpu, 内存，网卡 等，
	/// </summary>
	public class HeartbeatTask : IHeartbeatTask
	{
		const string urlPath = "event/heartbeat";

		static HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

		private readonly Timer _timer;
		private readonly AgentConfiguration _agentConfigration;

		private bool canRun = false;

		public HeartbeatTask(AgentConfiguration configration)
		{
			_agentConfigration = configration;
			_timer = new Timer(Callback, null, 0, 5 * 1000);
		}

		public Task RunAsync()
		{
			canRun = true;
			return Task.CompletedTask;
		}

		private void Callback(object state)
		{
			if (!canRun)
				return;

			if (!_agentConfigration.Valid())
			{
				return;
			}

			string url = _agentConfigration.ServerUrl;
			if (!url.EndsWith("/")) url += "/";
			url += urlPath;

			try
			{
				// post event data to server ,the request data type is 'HeartbeatRequest'
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
