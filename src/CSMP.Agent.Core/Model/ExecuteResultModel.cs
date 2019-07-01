using CSMP.Model;

namespace CSMP.Agent.Model
{
    public class ExecuteResultModel
    {
        public CommandDefinition CommandDefinition { get; set; }

        public bool Success { get; set; }

        public object ResultData { get; set; }
    }
}
