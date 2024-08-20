using AutoMapper;
using EshopApi.Domain.Entities;
using EshopApi.Presentation.Models.DTOs;

namespace EshopApi.Presentation.Mapping
{
    public class MappingConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(dto => dto.ImageUrl, opt => opt.MapFrom(src => src.ImgUri))
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
