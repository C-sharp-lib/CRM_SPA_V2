using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("job-user-tasks")]
        public async Task<ActionResult<IEnumerable<JobUserTasks>>> JobUserTasks()
        {
            var jobUserTasks = await _context.JobUserTasks
                .Include(t => t.Task)
                .Include(t => t.Job)
                .Include(t => t.User)
                .ToListAsync();
            return Ok(jobUserTasks);
        }
        [HttpGet("campaign-user-tasks")]
        public async Task<ActionResult<IEnumerable<CampaignUserTasks>>> CampaignUserTasks()
        {
            var campaignUserTasks = await _context.CampaignUserTasks
                .Include(t => t.Campaign)
                .Include(t => t.Task)
                .Include(t => t.User)
                .ToListAsync();
            return Ok(campaignUserTasks);
        }
        [HttpGet("job-user-tasks/{id}")]
        public async Task<IActionResult> GetSingleJobUserTask(int id)
        {
            var task = await _context.JobUserTasks
                .Include(t => t.Job)
                .Include(t => t.User)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(t => t.JobUserTaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpGet("campaign-user-tasks/{id}")]
        public async Task<IActionResult> GetSingleCampaignUserTask(int id)
        {
            var task = await _context.CampaignUserTasks
                .Include(t => t.Campaign)
                .Include(t => t.User)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(t => t.CampaignUserTaskId == id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDTO task)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Tasks tasks = new Tasks
                    {
                        Title = task.Title,
                        Description = task.Description,
                        Priority = task.Priority,
                        Status = task.Status,
                        DueDate = task.DueDate,
                        CompletedDate = task.CompletedDate,
                    };
                    await _context.Tasks.AddAsync(tasks);
                    switch (task.TaskType)
                    {
                        case TaskType.JobUserTask:
                            var jobUserTask = new JobUserTasks
                            {
                                JobId = task.RelatedEntityId,
                                TaskId = tasks.TaskId,
                                UserId = task.UserId
                            };
                            await _context.JobUserTasks.AddAsync(jobUserTask);
                            break;
                        case TaskType.CampaignUserTask:
                            var campaignUserTasks = new CampaignUserTasks
                            {
                                CampaignId = task.RelatedEntityId,
                                TaskId = tasks.TaskId,
                                UserId = task.UserId
                            };
                            await _context.CampaignUserTasks.AddAsync(campaignUserTasks);
                            break;
                        default:
                            return BadRequest("Could not add task.");
                    }
                    await _context.SaveChangesAsync();
                    return Ok(tasks);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
            if (task == null)
            {
                return BadRequest();
            }
            _context.Tasks.Remove(task);
            return Ok($"Task with the id: {id} was deleted.");
        }
    }
}
