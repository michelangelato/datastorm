using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class ImmobileDTO
    {
        public int Id { get; set; }
        public decimal MetriQuadri { get; set; }
        public float LatitudinePunto { get; set; }
        public float LongitudinePunto { get; set; }
        public string Indirizzo { get; set; }
        public string Comune { get; set; }
        public short NumeroPersoneResidenti { get; set; }
        public int? NumeroPiano { get; set; }
        public TipologiaImmobile TipoImmobile { get; set; }
    }
}
