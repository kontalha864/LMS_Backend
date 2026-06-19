using LMS_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext db;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment environment, AppDbContext db)
        {
            _logger = logger;
            _configuration = configuration;
            _environment = environment;
            this.db = db;
        }


        [HttpGet("getRole")]
        public async Task<IActionResult> getRole()
        {
            var roles = await db.Roles.ToListAsync();
            return Ok(roles);
        }
    }
}
