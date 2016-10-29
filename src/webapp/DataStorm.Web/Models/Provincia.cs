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
        [Key, StringLength(2, MinimumLength = 2), Column(TypeName = "char")]
        public string Sigla { get; set; }

        [Required, StringLength(40)]
        public string Denominazione { get; set; }

        public int RegioneID { get; set; }
        public virtual Regione Regione { get; set; }
    }
}
