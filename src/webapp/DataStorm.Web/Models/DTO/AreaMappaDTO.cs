using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class AreaMappaDTO
    {
        public virtual int Id { get; set; }
        public virtual string TipoMappa { get; set; }
        public virtual List<PuntoMappaDTO> PuntiMappa { get; set; }
    }
}
