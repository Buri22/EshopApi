using EshopApi.Domain.Entities;
using EshopApi.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Infrastructure.Data.DbContexts
{
    public class EshopDbContext : DbContext
    {
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<AccountEntity> AccountEntities { get; set; }

        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {
        }
        public EshopDbContext()
        {
        }
    }
}
