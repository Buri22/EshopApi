using EshopApi.Infrastructure.Data.Entities;

namespace EshopApi.Infrastructure.Data
{
    public static class EshopDbContextSeeder
    {
        public static void GenerateSeed(EshopDbContext dbContext)
        {
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
            dbContext.SaveChanges();
        }
    }
}
