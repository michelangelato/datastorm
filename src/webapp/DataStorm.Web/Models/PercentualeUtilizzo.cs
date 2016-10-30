
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models
{
    public enum PercentualeUtilizzo : Int32 {
        Non_utilizzato = 0,
        Abbandonato = 1,
        Meno_del_30,
        Oltre_65 = 2,

    }
}