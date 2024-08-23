using AutoMapper;
using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data.Entities;

namespace EshopApi.Infrastructure.Data.Mapping
{
    public class MappingConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductEntity>().ReverseMap();
                cfg.CreateMap<Account, AccountEntity>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
