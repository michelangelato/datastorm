using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class ImmobileDTO
    {
        public int Id { get; set; }
        public string Indirizzo { get; set; }
        public string Comune { get; set; }
        public string TipoImmobile { get; set; }
    }
}