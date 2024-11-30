using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors()]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ApplicationDbContext _context;
        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context) 
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> CustomerList()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerDTO customer)
        {
            _logger.LogInformation($"GET at CustomerCreate:, {DateTime.UtcNow}");
            try
            {
                _logger.LogDebug("POST customer before execution");
                Customers customers= new Customers
                {
                    CustomerType = customer.CustomerType,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Fax = customer.Fax,
                    Status = customer.Status,
                    Address = customer.Address,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode,
                    Industry = customer.Industry,
                    Website = customer.Website,
                    ContactPerson = customer.ContactPerson,
                    Notes = customer.Notes,
                };
                _context.Customers.Add(customers);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Created and added: " + customers);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", "Error in posting customer");
                return StatusCode(500, new { Message = "Internal Service Error" });
            }
        }
    }
}
