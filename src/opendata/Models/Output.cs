using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;

namespace OpenDataProcessor.Models {

    public class Output {
        public string Codice {get; set;}
        public int NumeroDiPiani {get;set;}
        public string Proprieta {get;set;}
        public int AnnoDiCostruzione {get;set;}
        public string Costruzione {get;set;} 
        public int AreaInMq {get; set;}
        public int PercentualeUtilizzo {get;set;}
        public string Uso {get;set;}
        public string Posizione {get;set;}
        public string CateneCordoli {get;set;}
        public string DissestiTerreno {get;set;}
        public string Terreno {get;set;}

        public string Regione {get; set;}
        public string Latitudine {get; set;}
        public string Longitudine {get;set;}
        public string Agibilita {get; set;}
        public string Provincia {get;set;}
        public string Comune {get;set;}


    }

    public class OutputClassMap : CsvClassMap<Output> {
        public OutputClassMap ()
        {
          Map(m => m.Proprieta).Index(0);
          Map(m => m.Regione).Index(1);
          Map(m => m.Codice).Index(2);
          Map(m => m.Latitudine).Index(3);
          Map(m => m.Longitudine).Index(4);
          Map(m => m.Agibilita).Index(5);
          Map(m => m.Provincia).Index(6);
          Map(m => m.Comune).Index(12);

        }
    }
}