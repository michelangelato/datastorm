using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Comune
    {
        public int ID { get; set; }

        [Required]
        public string Denominazione { get; set; }

        public string SiglaProvincia { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
