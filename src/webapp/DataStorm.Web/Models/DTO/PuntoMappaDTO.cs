using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class PuntoMappaDTO
    {
        public int Id { get; set; }
        public float LatitudinePunto { get; set; }
        public float LongitudinePunto { get; set; }
    }
}
