using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum TipoDiPosizione:Int32
    {
        Isolato=1,
        Interno=2,
        DiEstremita=3,
        DiAngolo=4
    }
}
