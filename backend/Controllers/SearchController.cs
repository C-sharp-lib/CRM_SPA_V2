using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context, ILogger<SearchController> logger) 
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) 
            {
                return BadRequest(new {Message = "Keyword cannot be empty."});
            }
            var results = await _context.Customers
                .Where(c => 
                    c.Name.ToLower().Contains(keyword.ToLower()) || 
                    c.Address.ToLower().Contains(keyword.ToLower()) || 
                    c.Status.ToLower().Contains(keyword.ToLower()) || 
                    c.CustomerType.ToLower().Contains(keyword.ToLower()))
                .ToListAsync();
            if (results.Any()) 
            { 
                return NotFound("Keyword cannot be found. Try again.");
            }
            return Ok(results);
        }
    }
}
