using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Topic
    {
        public virtual int Id { get; set; }
        public virtual string Codice { get; set; }
        public virtual List<AvvisoTopic> AvvisiTopics { get; set; }
    }
}
