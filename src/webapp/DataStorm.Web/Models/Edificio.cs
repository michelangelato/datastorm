using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Edificio
    {
        public virtual int Id { get; set; }
        public virtual short NumeroPersoneResidenti { get; set; }
        public virtual Appartamento AppartamentoEdifcio { get; set; }
    }
}
