using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class AvvisoTopic
    {
        public virtual int Id { get; set; }
        public virtual Avviso AvvisoRiferimento { get; set; }
        public virtual Topic TopicRiferimento { get; set; }
    }
}
