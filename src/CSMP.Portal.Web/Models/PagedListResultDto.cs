using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Models
{
    public class PagedListResultDto<T>
    {
        public int Count { get; }

        public IEnumerable<T> List { get; }

        public PagedListResultDto(IEnumerable<T> ts, int count)
        {
            this.Count = count;
            this.List = ts;
        }
    }
}
