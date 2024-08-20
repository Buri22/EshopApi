using Microsoft.EntityFrameworkCore;

namespace EshopApi.Data
{
    public class EshopDbContext(DbContextOptions<EshopDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
