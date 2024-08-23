using EshopApi.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace EshopApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController(EshopDbInitializer dbInitializer) : ControllerBase
    {
        [HttpPost]
        public IActionResult GenerateSeedData()
        {
            var success = dbInitializer.GenerateSeed();

            if (success) return Ok("Seed data generated successfully!");
            else return BadRequest("Attempt to GenerateSeed, but database is not empty.");
        }
    }
}
