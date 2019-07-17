using CSMP.Agent.Model;
using CSMP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Agent.Executors
{
    public interface ICommandExecutor
    {
        ExecuteResultModel ExecuteAsync(CommandDefinition definition);
    }
}
