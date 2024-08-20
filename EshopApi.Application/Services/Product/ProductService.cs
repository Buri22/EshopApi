using EshopApi.Application.Repositories;
using EshopApi.Domain.Entities;
using EshopApi.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopApi.Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProductById(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            return productRepository.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            ValidateProduct(product);

            // Add business logic here, if needed
            productRepository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            ValidateProduct(product);

            // Add business logic here, if needed
            productRepository.UpdateProduct(product);
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
