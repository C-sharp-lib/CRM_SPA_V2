using backend.DTO;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ILogger<CampaignController> _logger;
        private readonly ApplicationDbContext _context;
        public CampaignController(ILogger<CampaignController> logger, ApplicationDbContext context) 
        { 
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetCampaigns()
        {
            return Ok(await _context.Campaigns
                .Include(c => c.CampaignUserTasks)
                .ThenInclude(c => c.Task)
                .Include(ut => ut.CampaignUserTasks)
                .ThenInclude(ut => ut.User)
                .Include(cn => cn.CampaignUserNotes)
                .ThenInclude(cn => cn.Notes)
                .Include(cn => cn.CampaignUserNotes)
                .ThenInclude(cn => cn.User)
                .ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCampaign(int id)
        {
            var campaign = await _context.Campaigns
                 .Include(c => c.CampaignUserTasks)
                .ThenInclude(c => c.Task)
                .Include(ut => ut.CampaignUserTasks)
                .ThenInclude(ut => ut.User)
                .Include(cn => cn.CampaignUserNotes)
                .ThenInclude(cn => cn.Notes)
                .Include(cn => cn.CampaignUserNotes)
                .ThenInclude(cn => cn.User)
                .FirstOrDefaultAsync(c => c.CampaignId == id);
            if(campaign == null)
            {
                return NotFound($"Campaign with the id: {id} does not exist.");
            }
            return Ok(campaign);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignDTO campaign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Campaigns campaigns = new Campaigns
                    {
                        Title = campaign.Title,
                        Description = campaign.Description,
                        Type = campaign.Type,
                        Status = campaign.Status,
                        StartDate = campaign.StartDate,
                        EndDate = campaign.EndDate,
                        Budget = campaign.Budget,
                        Spend = campaign.Spend,
                        TargetAudience = campaign.TargetAudience,
                        Channel = campaign.Channel,
                        Goals = campaign.Goals,
                        RevenueTarget = campaign.RevenueTarget,
                        ActualRevenue = campaign.ActualRevenue,
                        Impressions = campaign.Impressions,
                        Clicks = campaign.Clicks,
                        LeadsGenerated = campaign.LeadsGenerated,
                        Conversions = campaign.Conversions,
                        ROI = campaign.ROI
                    };

                    _context.Campaigns.Add(campaigns);
                    await _context.SaveChangesAsync();
                    return Ok(campaigns);
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"There was an error adding a new campaign: {ex.Message}");
            }
            return BadRequest("Could not add campaign, outside the try block");
        }
    }
}
