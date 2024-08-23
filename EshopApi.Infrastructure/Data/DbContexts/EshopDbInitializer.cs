using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data.Entities;

namespace EshopApi.Infrastructure.Data.DbContexts
{
    public class EshopDbInitializer(EshopDbContext dbContext)
    {
        public bool GenerateSeed()
        {
            if (dbContext.ProductEntities.Any() || dbContext.AccountEntities.Any()) return false;

            // Create sample products
            var products = new[]
            {
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product 1", ImgUri = "https://example.com/image1.png", Price = 10.99m },
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product 2", ImgUri = "https://example.com/image2.png", Price = 9.99m, Description = "This is the cheapest product" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product 3", ImgUri = "https://example.com/image3.png", Price = 12.99m },
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product 4", ImgUri = "https://example.com/image4.png", Price = 125.99m },
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product 5", ImgUri = "https://example.com/image5.png", Price = 212.99m, Description = "This is the most expensive product" },
            };

            dbContext.ProductEntities.AddRange(products);

            // Create Account for authentication
            var account = new AccountEntity
            {
                Id = Guid.Parse("d5a6ae30-b59e-4ef3-878e-fee1f3a2da21"),
                Secret = "5601610ff75c5b5de572fb8c8427f328"
            };

            dbContext.AccountEntities.Add(account);

            dbContext.SaveChanges();

            return true;
        }
    }
}
