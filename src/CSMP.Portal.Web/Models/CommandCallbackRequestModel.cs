using CSMP.Model;
using CSMP.Portal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class CommandCallbackRequestModel
    {
        public string CommandId { get; set; }

        public CommandStatus Status { get; set; }

        public string Result { get; set; }
    }
}
