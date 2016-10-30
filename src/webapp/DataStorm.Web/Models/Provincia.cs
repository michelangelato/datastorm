using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Provincia
    {
        [Key]
        public string Sigla { get; set; }

        [Required]
        public string Denominazione { get; set; }

        public int RegioneID { get; set; }
        public virtual Regione Regione { get; set; }
    }
}
