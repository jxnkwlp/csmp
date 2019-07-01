using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Portal.Domains
{
    public class HeartbeatCollect : BaseCreationEntity, IAgentIdentifier
    {
        public string AgentIdentifier { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }
    }
}
