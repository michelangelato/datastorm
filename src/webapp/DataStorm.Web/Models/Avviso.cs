using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Avviso
    {
        public virtual int Id { get; set; }
        public virtual string Titolo { get; set; }
        public virtual string Descrizione { get; set; }

        public virtual List<ImmagineAvviso> ImmaginiAvviso { get; set; }
        public virtual List<LinkAvviso> Links { get; set; }
        public virtual List<AreaMappa> AreeMappe { get; set; }

        public dynamic ToDTO()
        {
            return new
            {
                Titolo,
                Descrizione,
                Immagini = ImmaginiAvviso.Select(i => new { i.Larghezza, i.Altezza, i.TitoloImmagine, i.UrlImmagine }),
                Links = Links.Select(l => new { l.Titolo, l.Url }),
                AreeMappe = AreeMappe.Select(am => new
                {
                    am.TipoMappa,
                    PuntiMappa = am.PuntiMappa.Select(p => new { p.LatitudinePunto, p.LongitudinePunto })
                })
            };
        }
    }
}
