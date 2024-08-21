using EshopApi.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace EshopApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController(EshopDbContext context) : ControllerBase
    {
        private readonly EshopDbContext _context = context;

        [HttpPost]
        public async Task<IActionResult> GenerateSeedData()
        {
            await _context.Database.EnsureCreatedAsync();

            if (_context.ProductEntities.Any())
            {
                return BadRequest("Attempt to GenerateSeed, but database is not empty.");
            }

            EshopDbContextSeeder.GenerateSeed(_context);

            return Ok("Seed data generated successfully!");
        }
    }
}
