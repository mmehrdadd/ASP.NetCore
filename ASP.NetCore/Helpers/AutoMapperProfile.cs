using ASP.NetCore.DTOs;
using ASP.NetCore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Generes, GenresDTOs>().ReverseMap();
            CreateMap<GenreCreationDTO, Generes>();
        }
    }
}
