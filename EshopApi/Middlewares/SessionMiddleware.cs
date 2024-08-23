using EshopApi.Application.Services;
using EshopApi.Domain.Exceptions;
using System.Net;

namespace EshopApi.Presentation.Middlewares
{
    public class SessionMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var accounIdString = context.Items["AccountId"]?.ToString();
                if (string.IsNullOrEmpty(accounIdString)) throw new ValidationException("AccountId is not defined.");

                // TODO: Add authorization process, validate account role using account DB data

                using var scope = context.RequestServices.GetService<IServiceScopeFactory>().CreateScope();
                var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
                // Use the accountService instance
                context.Items["Account"] = accountService.GetAccountById(Guid.Parse(accounIdString))
                    ?? throw new ValidationException("Account was not found.");
            }
            catch (Exception ex)
            {
                // If the account is not found, return an unauthorized response
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync($"Unauthorized - Provided JWT AccountId is invalid: {ex.Message}");
                return;
            }

            // Continue processing the request
            await next(context);
        }
    }
}
