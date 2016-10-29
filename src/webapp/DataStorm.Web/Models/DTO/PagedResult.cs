using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class PagedResult<T> where T:class
    {
        public virtual IEnumerable<T> Risultati { get; set; }
        public virtual int TotalNumber { get; set; }
        public virtual int PageNumber { get; set; }
    }
}
