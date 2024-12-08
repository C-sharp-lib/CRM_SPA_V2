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
        [HttpPost("create-campaign")]
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


        [HttpPut("update-campaign/{id}")]
        public async Task<IActionResult> UpdateCampaign(int id, [FromBody] CampaignDTO campaign)
        {
            try
            {
                var camp = await _context.Campaigns.SingleOrDefaultAsync(c => c.CampaignId == id);
                if (camp == null) 
                {
                    return NotFound($"Campaign with the id: {id} does not exist.");
                }
                if (ModelState.IsValid)
                {
                    campaign.Title = camp.Title;
                    campaign.Description = camp.Description;
                    campaign.Type = camp.Type;
                    campaign.Status = camp.Status;
                    campaign.StartDate = camp.StartDate;
                    campaign.EndDate = camp.EndDate;
                    campaign.Budget = camp.Budget;
                    campaign.Spend = camp.Spend;
                    campaign.TargetAudience = camp.TargetAudience;
                    campaign.Channel = camp.Channel;
                    campaign.Goals = camp.Goals;
                    campaign.RevenueTarget = camp.RevenueTarget;
                    campaign.ActualRevenue = camp.ActualRevenue;
                    campaign.Impressions = camp.Impressions;
                    campaign.Clicks = camp.Clicks;
                    campaign.LeadsGenerated = camp.LeadsGenerated;
                    campaign.Conversions = camp.Conversions;
                    campaign.ROI = camp.ROI;
                    _context.Campaigns.Update(camp);
                    await _context.SaveChangesAsync();
                    return Ok(camp);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Could not update campaigns");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaign(int id)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.CampaignId == id);
            if(campaign == null)
            {
                return BadRequest($"Could not find campaign with the id: {id}.");
            }
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
            return Ok("Delete campaign.");
        }
    }
}
