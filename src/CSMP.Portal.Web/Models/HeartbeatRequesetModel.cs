using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class HeartbeatRequesetModel
    {
        public Dictionary<string, object> Snapshots { get; set; }
    }
}
