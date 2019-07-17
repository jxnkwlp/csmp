using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class ListRequestDto
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

    }
}
