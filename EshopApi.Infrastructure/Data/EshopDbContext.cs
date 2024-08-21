using EshopApi.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Data
{
    public class EshopDbContext : DbContext
    {
        public DbSet<ProductEntity> ProductEntities { get; set; }

        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {
        }
        public EshopDbContext()
        {
        }
    }
}
