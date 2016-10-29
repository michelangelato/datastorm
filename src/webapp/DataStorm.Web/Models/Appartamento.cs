using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Appartamento
    {
        public virtual int Id { get; set; }
        public virtual Utente UtenteAppartenenza { get; set; }
        public virtual decimal MetriQuadri { get; set; }
        public virtual PuntoMappa PuntoMappa { get; set; }
    }
}
