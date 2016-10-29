using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Appartamento
    {
        public virtual int Id { get; set; }
        public Utente UtenteAppartenenza { get; set; }
    }
}
