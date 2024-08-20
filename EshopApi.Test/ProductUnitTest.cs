using Bogus;
using EshopApi.Application.Repositories;
using EshopApi.Application.Services;
using EshopApi.Domain.Entities;
using Moq;

namespace EshopApi.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private readonly Faker<Product> _productFaker;

        public ProductServiceTests()
        {
            _productFaker = new Faker<Product>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => f.Finance.Amount(100, 1000));
        }

        [Test]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var products = _productFaker.Generate(2);
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.GetAllProducts()).Returns(products);

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var result = productService.GetAllProducts();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetProductById_ProductExists_ReturnsProduct()
        {
            // Arrange
            var product = _productFaker.Generate();
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.GetProductById(product.Id)).Returns(product);

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var result = productService.GetProductById(product.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(product.Id));
        }

        [Test]
        public void GetProductById_ProductDoesNotExist_ReturnsNull()
        {
            // Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.GetProductById(Guid.NewGuid())).Returns((Product)null);

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var result = productService.GetProductById(Guid.NewGuid());

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void AddProduct_ValidProduct_AddsProduct()
        {
            // Arrange
            var product = _productFaker.Generate();
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.AddProduct(It.IsAny<Product>())).Verifiable();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            productService.AddProduct(product);

            // Assert
            productRepositoryMock.Verify(r => r.AddProduct(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void UpdateProduct_ValidProduct_UpdatesProduct()
        {
            // Arrange
            var product = _productFaker.Generate();
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.UpdateProduct(It.IsAny<Product>())).Verifiable();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            productService.UpdateProduct(product);

            // Assert
            productRepositoryMock.Verify(r => r.UpdateProduct(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void DeleteProduct_ValidProductId_DeletesProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(r => r.DeleteProduct(productId)).Verifiable();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            productService.DeleteProduct(productId);

            // Assert
            productRepositoryMock.Verify(r => r.DeleteProduct(productId), Times.Once);
        }
    }
}