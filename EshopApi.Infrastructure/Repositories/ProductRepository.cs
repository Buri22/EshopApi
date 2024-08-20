using AutoMapper;
using AutoMapper.QueryableExtensions;
using EshopApi.Application.Repositories;
using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data;
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

        public Product GetProductById(Guid id)
        {
            var productEntity = context.ProductEntities.Find(id);
            return productEntity != null ? _mapper.Map<Product>(productEntity) : null;
        }

        public void AddProduct(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            context.ProductEntities.Add(productEntity);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            context.ProductEntities.Update(productEntity);
            context.SaveChanges();
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
