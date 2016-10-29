using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Immobile
    {
        public virtual int Id { get; set; }
        public virtual Utente UtenteAppartenenza { get; set; }
        public virtual decimal MetriQuadri { get; set; }
        public virtual PuntoMappa PuntoMappa { get; set; }
        public virtual string Indirizzo { get; set; }
        public virtual string Comune { get; set; }
        public virtual short NumeroPersoneResidenti { get; set; }
        public int? NumeroPiano { get; set; }
        public virtual TipologiaImmobile TipoImmobile { get; set; }

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
