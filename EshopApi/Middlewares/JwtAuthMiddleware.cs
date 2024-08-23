using EshopApi.Presentation.Services;
using System.Net;

namespace EshopApi.Presentation.Middlewares
{
    public class JwtAuthMiddleware(RequestDelegate next, IJwtService jwtService)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // Get the token from the Authorization header
            var token = context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    // Verify the token using the JwtSecurityTokenHandler
                    var validationResult = jwtService.ValidateToken(token);

                    // Store the account ID in the HttpContext items for later use
                    context.Items[nameof(validationResult.AccountId)] = validationResult.AccountId;
                }
                catch (Exception ex)
                {
                    // If the token is invalid, return an unauthorized response
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync($"Unauthorized - Provided JWT token is invalid: {ex.Message}");
                    return;
                }
            }

            // Continue processing the request
            await next(context);
        }
    }
}
