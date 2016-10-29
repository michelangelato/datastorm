using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum TipoAgibilita:Int32
    {
        InformazioneMancante = 0,
        A_Agibile = 1,
        B_AgibileConProntoIntervento = 2,
        C_ParzialmenteInagibile = 3,
        D_TemporaneamenteInagibile = 4,
        E_Inagibile = 5,
        F_InagibilePerRischioEsterno = 6

    }
}
