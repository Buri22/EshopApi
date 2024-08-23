using EshopApi.Domain.Exceptions;
using EshopApi.Presentation.Middlewares;
using EshopApi.Presentation.Models;
using EshopApi.Presentation.Services;
using Microsoft.IdentityModel.Tokens;

namespace EshopApi.Presentation.Extensions
{
    public static class JwtAuthenticationDIExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authConfig = configuration.GetSection("Authentication").Get<AuthenticationConfig>();
            if (authConfig == null || string.IsNullOrWhiteSpace(authConfig.Secret))
                throw new ValidationException("Authentication configuration is invalid.");

            var tokenValidationParams = new TokenValidationParameters
            {
                // Validate the signature
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(authConfig.Secret)),

                // Validate the token expiration time
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,

                // Optional: set clock skew to account for server/client time differences
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParams;
            });

            services.AddSingleton(tokenValidationParams);
            services.AddTransient<IJwtService>(serviceProvider => 
                new JwtService(serviceProvider.GetService<TokenValidationParameters>(), authConfig.TokenExpiration));
            //services.AddTransient<JwtAuthMiddleware>();
        }
    }
}
