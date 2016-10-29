using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Segnalazione
    {
        public virtual string Id { get; set; }
        public virtual Utente UtenteSegnalazione { get; set; }
        public virtual TipologiaSegnalazione TipoSegnalazione { get; set; }
        public virtual string Descrizione { get; set; }
        
        public virtual PuntoMappa Localizzazione { get; set; }
    }
}
