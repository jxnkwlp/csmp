using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class AccountDto : BaseEntityDto
    {
        [Required]
        [MaxLength(32)]
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        [MaxLength(128)]
        public string Password { get; set; }
    }
}
