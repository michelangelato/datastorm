using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Catasto
    {
        public int IdCatasto { get; set; }
        public string Comune {get;set;}
        public string Indirizzo {get;set;}

        #region Proprietà utili per la stima del danno
        public int NumeroDiPiani {get;set;}
        public TipoDiProprieta Proprieta {get;set;}
        public int AnnoDiCostruzione {get;set;}
        public TipoDiCostruzione Costruzione {get;set;} 
        public int AreaInMq {get;set;}
        public int PercentualeUtilizzo {get;set;}
        public TipoDiUso Uso {get;set;}
        public TipoDiPosizione Posizione {get;set;}
        public TipoCateneCordoli CateneCordoli {get;set;}

        public TipoDissestiTerreno DissestiTerreno {get;set;}
        public TipoDiTerreno Terreno {get;set;}

        #endregion
    }
}