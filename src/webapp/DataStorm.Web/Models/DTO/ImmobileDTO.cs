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
        public virtual string NumeroDiPiani { get; set; }
        public virtual string Proprieta { get; set; }
        public virtual string AnnoDiCostruzione { get; set; }
        public virtual string Costruzione { get; set; }
        public virtual string PercentualeUtilizzo { get; set; }
        public virtual string Uso { get; set; }
        public virtual string Posizione { get; set; }
        public virtual string CateneCordoli { get; set; }
    }
}