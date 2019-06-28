using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Model
{
	public class ExecuteRequestModel
	{
		public Guid CommandId { get; set; }

		public string Scripts { get; set; }

	}
}
