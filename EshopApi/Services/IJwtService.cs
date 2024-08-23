using EshopApi.Presentation.Models;

namespace EshopApi.Presentation.Services
{
    public interface IJwtService
    {
        string GenerateToken(Guid accountId);
        JwtTokenValidationResult ValidateToken(string token);
    }
}
