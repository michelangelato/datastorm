using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum TipoDiTerreno:Int32
    {
        InformazioneMancante = 0,
        Pianura = 1,
        PendioLeggero = 2,
        PendioForte = 3,
        Cresta = 4
    }
}
