using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class AziendaDTO
    {
        public virtual int Id { get; set; }
        public virtual string RagioneSociale { get; set; }
        public virtual string PartitaIva { get; set; }
        public virtual string Indirizzo { get; set; }
        public virtual PuntoMappa Posizione { get; set; }
        public virtual string Citta { get; set; }
        public virtual List<TipologiaLavoroDTO> TipologieLavori { get; set; }
    }
}
