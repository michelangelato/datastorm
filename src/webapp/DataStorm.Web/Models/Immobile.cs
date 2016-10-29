using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Immobile
    {
        public virtual int Id { get; set; }
        public virtual Utente UtenteAppartenenza { get; set; }
        public virtual decimal MetriQuadri { get; set; }
        public virtual PuntoMappa PuntoMappa { get; set; }
        public virtual string Indirizzo { get; set; }
        public virtual string Comune { get; set; }
        public virtual short NumeroPersoneResidenti { get; set; }
        public int? NumeroPiano { get; set; }
        public virtual TipologiaImmobile TipoImmobile { get; set; }
    }
}
