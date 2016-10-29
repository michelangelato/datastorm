using AutoMapper;
using DataStorm.Web.Models;
using DataStorm.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.MapperInitializer
{
    public class MapperInitializer
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Immobile, ImmobileDTO>());
            
        }  
     
    }
}
