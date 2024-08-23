using EshopApi.Application.Services;
using EshopApi.Presentation.Models.DTOs;
using EshopApi.Presentation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EshopApi.Application.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IJwtService jwtService, IAccountService accountService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            // Validate the account ID and secret vs DB values
            if (accountService.IsValidAccountCredentials(model.AccountId, model.AccountSecret))
            {
                var token = jwtService.GenerateToken(model.AccountId);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
