using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class LinkAvvisoDTO
    {
        public virtual int Id { get; set; }
        public virtual string Titolo { get; set; }
        public virtual string Url { get; set; }
    }
}
