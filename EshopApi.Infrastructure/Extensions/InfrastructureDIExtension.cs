using EshopApi.Application.Repositories;
using EshopApi.Infrastructure.Data.DbContexts;
using EshopApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EshopApi.Infrastructure.Extensions
{
    public static class InfrastructureDIExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Check what kind of DB is needed for development
            var useMockData = configuration.GetValue<bool>("UseMockData");
            if (useMockData)
            {
                services.AddDbContext<EshopDbContext, MockDbContext>();
            }
            else
            {
                services.AddDbContext<EshopDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("AlzaEshopApiDb")
                    )
                );
            }

            services.AddTransient<EshopDbInitializer>();

            // Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
        }
    }
}
