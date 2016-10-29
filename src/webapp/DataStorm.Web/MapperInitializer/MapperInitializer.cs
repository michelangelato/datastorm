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
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Immobile, ImmobileDTO>()
                .ForMember(dst=>dst.TipoImmobile,opt=>opt.MapFrom(src=>src.TipoImmobile.ToString()));
                cfg.CreateMap<ImmobileDTO, Immobile>()
                .ForMember(dst => dst.TipoImmobile, opt => opt.Ignore())
                ;
                cfg.CreateMap<TipologiaLavoro, TipologiaLavoroDTO>();
                cfg.CreateMap<Azienda, AziendaDTO>()
                    .ForMember(dst => dst.TipologieLavori,
                    opt => opt.MapFrom(src => src.AziendaTipoLavoro.Select(aztl => aztl.TipoLavoro)));
                }
            
            );
            
        }  
     
    }
}
