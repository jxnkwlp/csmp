using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent
{
	public class AgentConfiguration
	{
		public string Token { get; set; }

		public string ServerUrl { get; set; }

		public bool Valid()
		{ 
			return true;
		}
	}
}
