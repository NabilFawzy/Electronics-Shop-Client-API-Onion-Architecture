using AutoMapper;
using Microsoft.Extensions.Configuration;
using OnionArch.Data.DTOs;
using OnionArch.Data.Entities;

namespace API.HelpClasses
{
    public class MappingProfile : Profile
    
    {
        public MappingProfile()
        {
       
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));

        }
       
    }
}
