using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class SegnalazioneDTO
    {
        public TipologiaSegnalazione TipoSegnalazione { get; set; }
        public string Descrizione { get; set; }
    }
}
