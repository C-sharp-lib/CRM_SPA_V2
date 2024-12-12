using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;
        private readonly ApplicationDbContext _context;
        public JobController(ILogger<JobController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobs>>> JobList()
        {
           var jobs = await _context.Jobs
                .Include(j => j.JobUserTasks)
                .ThenInclude(j => j.Task)
                .Include(j => j.JobUserTasks)
                .ThenInclude(j => j.User)
                .Include(jn => jn.JobUserNotes)
                .ThenInclude(jn => jn.Notes)
                .Include(jn => jn.JobUserNotes)
                .ThenInclude(jn => jn.User)
                .Include(c => c.CustomerJobs)
                .ThenInclude(c => c.Customers)
                .ToListAsync();
            return Ok(jobs);
        }
        [HttpGet("job-count")]
        public async Task<IActionResult> JobCount()
        {
            return Ok(await _context.Jobs.CountAsync());
        }
        [HttpGet("job-details/{id}")]
        public async Task<IActionResult> JobDetail(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.JobUserTasks)
                .ThenInclude(j => j.Task)
                .Include(j => j.JobUserTasks)
                .ThenInclude(j => j.User)
                .Include(jn => jn.JobUserNotes)
                .ThenInclude(jn => jn.Notes)
                .Include(jn => jn.JobUserNotes)
                .ThenInclude(jn => jn.User)
                .Include(c => c.CustomerJobs)
                .ThenInclude(c => c.Customers)
                .SingleOrDefaultAsync(j => j.JobId == id);
            if (job == null)
            {
                return NotFound($"The ID: {id} does not exist in our records.  Please try again.");
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> JobCreate([FromBody] JobDTO job)
        {
            _logger.LogInformation($"GET at JobCreate:, {DateTime.UtcNow}");
            try
            {
                _logger.LogDebug("POST job before execution");
                Jobs jobs = new Jobs
                {
                    JobTitle = job.JobTitle,
                    JobDescription = job.JobDescription,
                    JobStatus = job.JobStatus,
                    StartDate = job.StartDate,
                    EndDate = job.EndDate,
                    Priority = job.Priority,
                    EstimatedCost = job.EstimatedCost,
                    ActualCost = job.ActualCost,
                    CreatedAt = job.CreatedAt,
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJob(int id, [FromBody] JobDTO job) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateJob = await _context.Jobs.SingleOrDefaultAsync(j => j.JobId == id);
                    if (updateJob == null)
                    {
                        return NotFound($"Can't update the job by the id: {id} that you are looking for because it does not exist.");
                    }
                    updateJob.JobTitle = job.JobTitle;
                    updateJob.JobDescription = job.JobDescription;
                    updateJob.JobStatus = job.JobStatus;
                    updateJob.StartDate = job.StartDate;
                    updateJob.EndDate = job.EndDate;
                    updateJob.Priority = job.Priority;
                    updateJob.EstimatedCost = job.EstimatedCost;
                    updateJob.ActualCost = job.ActualCost;
                    updateJob.CreatedAt = job.CreatedAt;
                    updateJob.LastUpdatedDate = job.LastUpdatedDate;
                    _context.Jobs.Update(updateJob);
                    await _context.SaveChangesAsync();
                    return Ok(updateJob);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, new { Message = "DbUpdateConcurrencyException: when updating the job | " + ex.Message });
            }
            catch (DbUpdateException ex) 
            {
                return StatusCode(500, new { Message = "DbUpdateException: when updating a user | " + ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Exception: when updating a user | " + ex.Message });
            }
            return BadRequest(new {Message = "Cannot update job, check the code and system before continuing"});
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJob(int id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == id);
            if (job == null)
            {
                return NotFound(new { Message = $"The job with the id: {id} does not exist." });
            }
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return Ok(job);
        }
    }
}
