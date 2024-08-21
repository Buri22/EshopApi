using EshopApi.Application.Repositories;
using EshopApi.Infrastructure.Data.DbContexts;
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

            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
