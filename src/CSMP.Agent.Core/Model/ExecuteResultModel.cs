using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Model
{
	public class ExecuteResultModel
	{
		public Guid CommandId { get; set; }

		public object Data { get; set; }
	}
}
