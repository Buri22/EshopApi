using EshopApi.Application.Repositories;
using EshopApi.Domain.Entities;
using EshopApi.Domain.Exceptions;

namespace EshopApi.Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public IEnumerable<Product> GetPaginatedProducts(int page, int pageSize)
        {
            return productRepository.GetPaginatedProducts(page, pageSize);
        }

        public int GetEntityCount()
        {
            return productRepository.GetEntityCount();
        }

        public Product? GetProductById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            return productRepository.GetProductById(id);
        }

        public Product CreateProduct(Product product)
        {
            ValidateProduct(product);

            // Add business logic here, if needed
            return productRepository.CreateProduct(product);
        }

        public Product UpdateProduct(Product product)
        {
            ValidateProduct(product);

            // Add business logic here, if needed
            return productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            // Add business logic here, if needed
            productRepository.DeleteProduct(id);
        }

        private void ValidateProduct(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ValidationException("Product name is required");
            }

            if (product.Price <= 0)
            {
                throw new ValidationException("Product price must be a positive number");
            }

            // Add more validation rules as needed
        }
    }
}
