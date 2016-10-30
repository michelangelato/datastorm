using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public class Regione
    {
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
