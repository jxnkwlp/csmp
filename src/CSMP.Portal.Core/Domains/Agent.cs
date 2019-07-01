using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSMP.Portal.Domains
{
    public class Agent : BaseCreationEntity
    {
        [MaxLength(32)]
        public string Identifier { get; set; } = Guid.NewGuid().ToString("N");

    }
}
