using EshopApi.Presentation.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EshopApi.Presentation.Services
{
    public class JwtService(TokenValidationParameters tokenValidationParameters, int expirationInHours) : IJwtService
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();

        public string GenerateToken(Guid accountId)
        {
            // Create a list of claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, accountId.ToString()),   // Subject
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  // JWT ID
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64) // Issued At
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(expirationInHours),
                SigningCredentials = new SigningCredentials(tokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _jwtSecurityTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        public JwtTokenValidationResult ValidateToken(string token)
        {
            // Try to validate the token
            var claimsPrincipal = _jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out _);

            // Extract the account ID from the token claims
            var accountId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ArgumentException.ThrowIfNullOrWhiteSpace(accountId);

            return new JwtTokenValidationResult
            {
                AccountId = Guid.Parse(accountId)
            };
        }
    }
}
