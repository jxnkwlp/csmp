using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Agent
{
	public interface IHeartbeatTask
	{
		Task BeatAsync();

	}
}
