using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class AreaMappa
    {
        public virtual int Id { get; set; }
        public virtual TipoAreaMappa TipoMappa { get; set; }
        public virtual List<PuntoMappa> PuntiMappa { get; set; }

        public dynamic ToDTO()
        {
            return new
            {
                TipoMappa,
                PuntiMappa = PuntiMappa.Select(p => new { p.LatitudinePunto, p.LongitudinePunto })
            };
        }
    }
}
