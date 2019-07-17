using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class SecurityTokenDto : BaseEntityDto
    {
        public string Token { get; set; }

        public DateTime? Expired { get; set; }
    }
}
