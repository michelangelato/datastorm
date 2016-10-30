using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum TipoDiCostruzione:Int32
    {

        InformazioneMancante = 0,
        Con_telaio_in_acciaio = 1,
        Con_pareti_in_cemento_armato = 2,
        Con_telaio_in_cemento_armato = 3,
        Strutture_in_muratura = 4
    }
}
