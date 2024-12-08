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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            var tasks = await _context.Tasks
                .Include(t => t.UserTaskNotes)
                .ThenInclude(t => t.Note)
                .Include(t => t.UserTaskNotes)
                .ThenInclude(t => t.User)
                .Include(t => t.UserTaskNotes)
                .ThenInclude(t => t.Task)
                .Include(t => t.JobUserTasks)
                .ThenInclude(t => t.Job)
                .Include(t => t.JobUserTasks)
                .ThenInclude(t => t.User)
                .Include(t => t.JobUserTasks)
                .ThenInclude(t => t.Task)
                .Include(t => t.CampaignUserTasks)
                .ThenInclude(t => t.Campaign)
                .Include(t => t.CampaignUserTasks)
                .ThenInclude(t => t.User)
                .Include(t => t.CampaignUserTasks)
                .ThenInclude(t => t.Task)
                .ToListAsync();
            return Ok(tasks);
        }
        [HttpGet("task-details/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.UserTaskNotes)
                .ThenInclude(t => t.Note)
                .Include(t => t.UserTaskNotes)
                .ThenInclude(t => t.User)
                .Include(t => t.UserTaskNotes)
                .ThenInclude(t => t.Task)
                .Include(t => t.JobUserTasks)
                .ThenInclude(t => t.Job)
                .Include(t => t.JobUserTasks)
                .ThenInclude(t => t.User)
                .Include(t => t.JobUserTasks)
                .ThenInclude(t => t.Task)
                .Include(t => t.CampaignUserTasks)
                .ThenInclude(t => t.Campaign)
                .Include(t => t.CampaignUserTasks)
                .ThenInclude(t => t.User)
                .Include(t => t.CampaignUserTasks)
                .ThenInclude(t => t.Task)
                .FirstOrDefaultAsync(t => t.TaskId == id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }


    }
}
