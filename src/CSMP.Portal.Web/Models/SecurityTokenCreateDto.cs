using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class SecurityTokenCreateDto
    {
        public ValidityPeriod Period { get; set; }


        public enum ValidityPeriod
        {
            Long = 0,
            Day_1,
            Week_1,
            Month_1,
            Year_1,
        }
    }
}
