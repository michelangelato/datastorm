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
            .ForMember(dst => dst.TipoImmobile, opt => opt.MapFrom(src => src.TipoImmobile.ToString()))
            .ForMember(dst=>dst.TipoAgibilita, opt=>opt.MapFrom(src=>src.TipoAgibilita.ToString()))
            ;
            cfg.CreateMap<ImmobileDTO, Immobile>()
            .ForMember(dst => dst.TipoImmobile, opt => opt.Ignore())
            .ForMember(dst => dst.TipoAgibilita, opt => opt.Ignore());
            cfg.CreateMap<TipologiaLavoro, TipologiaLavoroDTO>();
            cfg.CreateMap<Azienda, AziendaDTO>()
                .ForMember(dst => dst.TipologieLavori,
                opt => opt.MapFrom(src => src.AziendaTipoLavoro.Select(aztl => aztl.TipoLavoro)));
            cfg.CreateMap<PuntoMappa, PuntoMappaDTO>();
            cfg.CreateMap<AreaMappa, AreaMappaDTO>()
            .ForMember(dst => dst.TipoMappa, opt => opt.MapFrom(src => src.TipoMappa.ToString()));
            cfg.CreateMap<AreaMappa,AreaMappa>()
                .ForMember(dst => dst.TipoMappa, opt => opt.MapFrom(src => src.TipoMappa.ToString()));
            cfg.CreateMap<LinkAvviso, LinkAvvisoDTO>();
            cfg.CreateMap<ImmagineAvviso, ImmagineAvvisoDTO>();
            cfg.CreateMap<Topic, TopicDTO>();
            cfg.CreateMap<Avviso, AvvisoDTO>()
            .ForMember(dst => dst.Topics, opt => opt.MapFrom(src => src.AvvisiTopics.Select(avt => avt.TopicRiferimento)));

                }
            
            
            );
            
        }  
     
    }
}
