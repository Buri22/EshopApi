using EshopApi.Domain.Entities;

namespace EshopApi.Application.Services
{
    public interface IProductService
    {
        public interface IProductService
        {
            IEnumerable<Product> GetAllProducts();
            Product GetProductById(Guid id);
            void AddProduct(Product product);
            void UpdateProduct(Product product);
            void DeleteProduct(Guid id);
        }
    }
}
