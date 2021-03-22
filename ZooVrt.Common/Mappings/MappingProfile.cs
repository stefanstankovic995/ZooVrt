using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZooVrt.Common.Models;
using ZooVrt.Domain.Entities;

namespace ZooVrt.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Domain.Entities.ZooVrt, ZooModel>();
            CreateMap<ZooModel, Domain.Entities.ZooVrt>();
            CreateMap<LokacijaModel, Lokacija>();
            CreateMap<Lokacija, LokacijaModel>();
            CreateMap<TipStanista, TipStanistaModel>();
            CreateMap<TipStanistaModel, TipStanista>();
        }
    }
}
