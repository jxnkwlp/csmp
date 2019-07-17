using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Model
{
    public class CommandDefinition
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Command { get; set; }

        public string[] Args { get; set; }
    }
}
