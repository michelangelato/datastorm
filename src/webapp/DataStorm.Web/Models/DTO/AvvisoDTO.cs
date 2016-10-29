using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class AvvisoDTO
    {
        public virtual int Id { get; set; }
        public virtual string Titolo { get; set; }
        public virtual string Descrizione { get; set; }

        public virtual List<ImmagineAvvisoDTO> ImmaginiAvviso { get; set; }
        public virtual List<LinkAvvisoDTO> Links { get; set; }
        public virtual List<AreaMappaDTO> AreeMappe { get; set; }
        public virtual List<TopicDTO> Topics { get; set; }
    }
}
