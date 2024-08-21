using AutoMapper;
using AutoMapper.QueryableExtensions;
using EshopApi.Application.Extensions;
using EshopApi.Application.Repositories;
using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data.DbContexts;
using EshopApi.Infrastructure.Data.Entities;
using EshopApi.Infrastructure.Data.Mapping;

namespace EshopApi.Infrastructure.Repositories
{
    public class ProductRepository(EshopDbContext context) : IProductRepository
    {
        private readonly IMapper _mapper = MappingConfig.CreateMapper();

        public IEnumerable<Product> GetAllProducts()
        {
            return context.ProductEntities.ProjectTo<Product>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<Product> GetPaginatedProducts(int page, int pageSize)
        {
            return context.ProductEntities
                .Paginate(page, pageSize)
                .ProjectTo<Product>(_mapper.ConfigurationProvider);
        }

        public int GetEntityCount()
        {
            return context.ProductEntities.Count();
        }

        public Product? GetProductById(Guid id)
        {
            var productEntity = context.ProductEntities.Find(id);
            return productEntity != null ? _mapper.Map<Product>(productEntity) : null;
        }

        public Product CreateProduct(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            context.ProductEntities.Add(productEntity);
            context.SaveChanges();
            return _mapper.Map<Product>(productEntity);
        }

        public Product UpdateProduct(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            context.ProductEntities.Update(productEntity);
            context.SaveChanges();
            return _mapper.Map<Product>(productEntity);
        }

        public void DeleteProduct(Guid id)
        {
            var productEntity = context.ProductEntities.Find(id);
            if (productEntity != null)
            {
                context.ProductEntities.Remove(productEntity);
                context.SaveChanges();
            }
        }
    }
}
