using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum TipoDiUso:Int32
    {
        InformazioneMancante = 0,
        Uffici=1,
        ServizioPubblico=2,
        Deposito=3,
        Commercio = 4,
        Strategico = 5,
        TuristicoRicettivo = 6,
        Produttivo = 7,
        Abitativo = 8
    }
}
