using EshopApi.Application.Services;
using EshopApi.Infrastructure.Data.DbContexts;
using EshopApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Test.UnitTests
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var productAmount = 4;
            var productRepository = new ProductRepository(new MockDbContext(productAmount));
            var productService = new ProductService(productRepository);

            // Act
            var result = productService.GetAllProducts();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(productAmount));
        }

        [Test]
        public void GetProductById_ProductExists_ReturnsProduct()
        {
            // Arrange
            var productRepository = new ProductRepository(new MockDbContext());
            var product = productRepository.GetAllProducts().ElementAt(0);
            var productService = new ProductService(productRepository);

            // Act
            var result = productService.GetProductById(product.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(product.Id));
                Assert.That(result.Name, Is.EqualTo(product.Name));
                Assert.That(result.Price, Is.EqualTo(product.Price));
            });
        }

        [Test]
        public void GetProductById_ProductDoesNotExist_ReturnsNull()
        {
            // Arrange
            var productRepository = new ProductRepository(new MockDbContext());
            var productService = new ProductService(productRepository);

            // Act
            var result = productService.GetProductById(Guid.NewGuid());

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void CreateProduct_ValidProduct_CreatesProduct()
        {
            // Arrange
            var dbContextMock = new MockDbContext();
            var product = MockDbContext.GenerateProduct();
            var productRepository = new ProductRepository(dbContextMock);
            var productService = new ProductService(productRepository);

            // Act
            var newProduct = productService.CreateProduct(product);

            // Assert
            var createdProduct = productService.GetProductById(newProduct.Id);
            Assert.That(createdProduct, Is.Not.Null);
        }

        [Test]
        public void UpdateProduct_ValidProduct_UpdatesProduct()
        {
            // Arrange
            var productEntities = MockDbContext.GenerateProductEntities(5);
            var dbContext = new MockDbContext(productEntities);
            var productRepository = new ProductRepository(dbContext);
            var productService = new ProductService(productRepository);

            var originalProductEntity = productEntities.First();
            var originalProduct = productService.GetProductById(originalProductEntity.Id);
            dbContext.Entry(originalProductEntity).State = EntityState.Detached;

            // Update OriginalProduct
            originalProduct!.Name = "Updated Product Name";
            originalProduct!.ImgUri = originalProduct.ImgUri;
            originalProduct!.Price += 12;
            originalProduct!.Description = "Updated Product Description";

            // Act
            productService.UpdateProduct(originalProduct);

            // Assert
            var updatedProductFromDb = productService.GetProductById(originalProduct.Id);
            Assert.That(updatedProductFromDb, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedProductFromDb.Name, Is.EqualTo(originalProduct.Name));
                Assert.That(updatedProductFromDb.Price, Is.EqualTo(originalProduct.Price));
                Assert.That(updatedProductFromDb.Description, Is.EqualTo(originalProduct.Description));
            });
        }

        [Test]
        public void DeleteProduct_ValidProductId_DeletesProduct()
        {
            // Arrange
            var productRepository = new ProductRepository(new MockDbContext());
            var productService = new ProductService(productRepository);
            var product = productRepository.GetAllProducts().ElementAt(0);
            var originalProductAmount = productService.GetEntityCount();

            // Act
            productService.DeleteProduct(product.Id);

            // Assert
            Assert.That(productService.GetEntityCount(), Is.EqualTo(originalProductAmount - 1));
        }
    }
}