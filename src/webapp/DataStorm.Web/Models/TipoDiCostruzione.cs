using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum TipoDiCostruzione:Int32
    {
        InformazioneMancante = 0,
        ConTelaioInAcciaio = 1,
        ConParetiInCementoArmato = 2,
        ConTelaioInCementoArmato = 3,
        StrutturaInMuratura = 4
    }
}
