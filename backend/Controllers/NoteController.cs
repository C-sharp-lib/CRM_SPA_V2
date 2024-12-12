using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("campaign-notes")]
        public async Task<ActionResult<IEnumerable<CampaignUserNotes>>> CampaignUserNotes()
        {
            var campaignUserNotes = await _context.CampaignUserNotes
                .Include(c => c.Campaign)
                .Include(c => c.User)
                .Include(c => c.Notes)
                .ToListAsync();
            return Ok(campaignUserNotes);
        }
        [HttpGet("job-notes")]
        public async Task<ActionResult<IEnumerable<JobUserNotes>>> JobUserNotes()
        {
            var jobUserNotes = await _context.JobUserNotes
                .Include(c => c.Job)
                .Include(c => c.User)   
                .Include(c => c.Notes)
                .ToListAsync();
            return Ok(jobUserNotes);
        }
        [HttpGet("task-notes")]
        public async Task<ActionResult<IEnumerable<UserTaskNotes>>> UserTaskNotes()
        {
            var userTaskNotes = await _context.UserTaskNotes
                .Include(c => c.User)
                .Include(c => c.Task)
                .Include(c => c.Note)
                .ToListAsync();
            return Ok(userTaskNotes);
        }

        [HttpGet("campaign-notes/{id}")]
        public async Task<ActionResult> GetSingleCampaignNote(int id)
        {
            var campaignNote = await _context.CampaignUserNotes
                .Include(c => c.Campaign)
                .Include(c => c.Notes)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.CampaignUserNoteId == id);
            if(campaignNote == null)
            {
                return NotFound();
            }
            return Ok(campaignNote);
        }
        [HttpGet("job-notes/{id}")]
        public async Task<ActionResult> GetSingleJobNote(int id)
        {
            var jobNote = await _context.JobUserNotes
                .Include(j => j.Notes)
                .Include(j => j.Job)
                .Include(j => j.User)
                .FirstOrDefaultAsync(j => j.JobUserNoteId == id);
            if(jobNote == null)
            {
                return NotFound();
            }
            return Ok(jobNote);
        }
        [HttpGet("task-notes/{id}")]
        public async Task<ActionResult> GetSingleTaskNote(int id)
        {
            var taskNote = await _context.UserTaskNotes
                .Include(t => t.Task)
                .Include(t => t.Note)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.UserTaskNoteId == id);
            if(taskNote == null)
            {
                return NotFound();
            }
            return Ok(taskNote);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteDTO note)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Notes notes = new Notes
                    {
                        Note = note.Note
                    };
                    _context.Notes.Add(notes);
                    await _context.SaveChangesAsync();
                    switch (note.NoteType)
                    {
                        case NoteType.JobUserNote:
                            var jobUserNote = new JobUserNotes
                            {
                                JobId = note.RelatedEntiityId,
                                UserId = note.UserId,
                                NoteId = notes.NoteId
                            };
                            await _context.JobUserNotes.AddAsync(jobUserNote);
                            break;
                        case NoteType.CampaignUserNote:
                            var campaignUserNote = new CampaignUserNotes
                            {
                                CampaignId = note.RelatedEntiityId,
                                UserId = note.UserId,
                                NoteId = notes.NoteId
                            };
                            await _context.CampaignUserNotes.AddAsync(campaignUserNote);
                            break;
                        case NoteType.UserTaskNote:
                            var userTaskNotes = new UserTaskNotes
                            {
                                UserId = note.UserId,
                                TaskId = note.RelatedEntiityId,
                                NoteId = notes.NoteId
                            };
                            await _context.UserTaskNotes.AddAsync(userTaskNotes);
                            break;

                        default:
                            return BadRequest("Could not add note");
                    }
                    await _context.SaveChangesAsync();
                    return Ok(notes);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == id);
            if(note == null)
            {
                return BadRequest();
            }
            _context.Notes.Remove(note);
            return Ok($"Note with the id: {id} was deleted.");
        }
    }
}
