using EshopApi.Application.Repositories;
using EshopApi.Infrastructure.Data;
using EshopApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EshopApi.Infrastructure.Extensions
{
    public static class DIExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EshopDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("AlzaEshopApiDb"),
                    b => b.MigrationsAssembly("EshopApi.Presentation")
                )
            );

            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
