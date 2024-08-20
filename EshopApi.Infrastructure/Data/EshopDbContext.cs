using EshopApi.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Data
{
    public class EshopDbContext(DbContextOptions<EshopDbContext> options) : DbContext(options)
    {
        public DbSet<ProductEntity> ProductEntities { get; set; }
    }
}
