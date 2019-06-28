using CSMP.Agent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Executors
{
	public interface ICommandExecutor
	{
		ExecuteResultModel ExecuteAsync(ExecuteRequestModel request);
	}
}
