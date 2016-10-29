using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Models.DTO
{
    public class ImmagineAvvisoDTO
    {
        public virtual string UrlImmagine { get; set; }
        public virtual int Altezza { get; set; }
        public virtual int Larghezza { get; set; }
        public virtual string TitoloImmagine { get; set; }
        public virtual int Id { get; set; }
    }
}
