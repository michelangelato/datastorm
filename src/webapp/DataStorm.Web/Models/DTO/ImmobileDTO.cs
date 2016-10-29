using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class ImmobileDTO
    {
        public virtual int Id { get; set; }
        public virtual string Indirizzo { get; set; }
        public virtual string Comune { get; set; }
        public virtual string TipoImmobile { get; set; }

        public virtual string TipoAgibilita { get; set; }
    }
}