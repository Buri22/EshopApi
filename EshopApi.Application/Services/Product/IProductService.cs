using EshopApi.Domain.Entities;

namespace EshopApi.Application.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetPaginatedProducts(int page, int pageSize);
        int GetEntityCount();
        Product? GetProductById(Guid id);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(Guid id);
    }
}
