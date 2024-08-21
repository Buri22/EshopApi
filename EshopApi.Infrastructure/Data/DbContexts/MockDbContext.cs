using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bogus;
using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data.Entities;
using EshopApi.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Data.DbContexts
{
    public class MockDbContext : EshopDbContext
    {
        private static readonly IMapper _mapper = MappingConfig.CreateMapper();

        public static readonly Faker<ProductEntity> _faker = new Faker<ProductEntity>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.ImgUri, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Price, f => f.Finance.Amount(100, 1000))
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription());

        public MockDbContext(int productAmount = 5)
        {
            var productEntities = GenerateProductEntities(productAmount);
            InitializeDbContext(productEntities);
        }
        public MockDbContext(List<ProductEntity> initialProductEntities)
            => InitializeDbContext(initialProductEntities);

        private void InitializeDbContext(List<ProductEntity> initialProductEntities)
        {
            // Ensure the database is deleted before creating a new instance
            Database.EnsureDeleted();

            ProductEntities.AddRange(initialProductEntities);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EshopApiTestDb");
        }

        public static List<ProductEntity> GenerateProductEntities(int productAmount = 1)
            => _faker.Generate(productAmount);
        public static ProductEntity GenerateProductEntity() => GenerateProductEntities().Single();
        public static List<Product> GenerateProducts(int productAmount = 1)
            => GenerateProductEntities(productAmount).AsQueryable()
                .ProjectTo<Product>(_mapper.ConfigurationProvider).ToList();
        public static Product GenerateProduct() => GenerateProducts().Single();
    }
}
