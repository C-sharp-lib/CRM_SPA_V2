using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class AspNetUsers : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName {  get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public bool? IsActive { get; set; } = false;
        public DateTime? HireDate { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public ICollection<AspNetUserRoles> UserRoles { get; set; }
        public ICollection<CustomerUsers> CustomerUsers { get; set; }
        public ICollection<UserTasks> UserTasks { get; set; }
        public ICollection<CampaignUserNotes> CampaignUserNotes { get; set; }
        public ICollection<JobUserNotes> JobUserNotes { get; set; }
        public ICollection<JobUserTasks> JobUserTasks { get; set; }
        public ICollection<CampaignUserTasks> CampaignUserTasks { get; set; }

    }
}
