using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Services;
using Microsoft.AspNetCore.Cors;
namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;
        private readonly ApplicationDbContext _context;
        public JobController(ILogger<JobController> logger, IConfiguration configuration, UserService userService, ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _userService = userService;
            _context = context;
        }

        [HttpGet("JobList")]
        public async Task<ActionResult<IEnumerable<Jobs>>> JobList() 
        {
            _logger.LogInformation($"GET at JobList: {DateTime.UtcNow}");
            try
            {
                _logger.LogDebug("Method JobList: retrieving results.");
                var jobs = await _context.Jobs.ToListAsync();
                if (jobs == null)
                {
                    return BadRequest("Jobs returned NULL");
                }
                return Ok(jobs);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message, "There has been an error, refer to the exception message.");
                return StatusCode(500, new { Message = "Internal Service Error" });
            }
        }

        [HttpGet("JobDetail/{id}")]
        public async Task<IActionResult> JobDetail(int id)
        {
            _logger.LogInformation($"GET at JobDetail: {id}, {DateTime.UtcNow}");
            try
            {
                var job = await _context.Jobs.SingleOrDefaultAsync(j => j.JobId == id);
                if (job == null)
                {
                    return BadRequest($"No Job of the ID: {id}");
                }
                return Ok(job);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}", "Error in get job detail");
                return StatusCode(500, new { Message = "Internal Service Error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> JobCreate(JobDTO job)
        {
            _logger.LogInformation($"GET at JobCreate:, {DateTime.UtcNow}");
            try
            {
                _logger.LogDebug("POST job before execution");
                Jobs jobs = new Jobs
                {
                    CustomerId = job.CustomerId,
                    JobTitle = job.JobTitle,
                    JobDescription = job.JobDescription,
                    JobStatus = job.JobStatus,
                    StartDate = job.StartDate,
                    EndDate = job.EndDate,
                    AssignedTo = job.AssignedTo,
                    Priority = job.Priority,
                    EstimatedCost = job.EstimatedCost,
                    ActualCost = job.ActualCost,
                    CreatedAt = job.CreatedAt,
                    CreatedBy = _userService.GetCurrentUserId(),
                    LastUpdatedDate = DateTime.Now,
                };
                _context.Jobs.Add(jobs);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Created and added: " + jobs);
                return Ok(jobs);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"{ex.Message}", "Error in posting job");
                return StatusCode(500, new { Message = "Internal Service Error" });
            }
        }
    }
}
