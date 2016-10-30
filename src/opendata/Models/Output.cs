using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.Configuration;

namespace OpenDataProcessor.Models {
         


    public class Output {
        public string Codice {get; set;}

        private string numeroDiPiani;
        public string NumeroDiPiani {
        get {
            return numeroDiPiani;
        }
        set {
             numeroDiPiani = value;
             }
        }
        private string proprieta;
        public string Proprieta {get
        {
            return proprieta;
            }
        set{proprieta = value;}
        }
        private string annoDiCostruzione;
        public string AnnoDiCostruzione {get {
            return annoDiCostruzione;
        }
        set{
            annoDiCostruzione = value.Replace(" ", "_");
        }
        }
        private string costruzione;
        public string Costruzione {get {return costruzione;} set{
            if (value == "Struttura non identificata" || value == "Dato non disponibile") return;
            costruzione = value.Replace(" ", "_");}}

        private string percentualeUtilizzo;
        public string PercentualeUtilizzo {get { return percentualeUtilizzo; } set{
if (value == "Dato non disponibile" || value == "Non finito" || value == "In costruzione") return;



             percentualeUtilizzo = value.Replace(" ", "_").Replace("%", "");
             } }
        private string uso;
        public string Uso {get {
        return uso;
        }
        set{
        uso = value.Replace(" ", "");
        }}
        private string posizione;
        public string Posizione {
            get{return posizione;}
            set {
                if (value == "Dato non disponibile") return;

if (value.Contains("isolato"))
posizione = "Isolato";
else if (value.Contains("estremit"))
posizione = "DiEstremita";
else if (value.Contains("interno"))
posizione = "Interno";
else if (value.Contains("angolo"))
posizione = "DiAngolo";
else
                posizione = value.Replace(" ", "").Replace("-", "_");
            }
        }
        private string cateneCordoli;
        public string CateneCordoli {
            get { return cateneCordoli; } set{
                
                if (value == "Dato non disponibile")
                return;


                cateneCordoli = value.Replace("_", ""); }
        }
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