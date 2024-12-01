using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("AspNetUsers", Schema ="crm_v1")]
    public class AspNetUsers : IdentityUser
    {
        [JsonIgnore]
        public string? FirstName { get; set; }
        [JsonIgnore]
        public string? MiddleName {  get; set; }
        [JsonIgnore]
        public string? LastName { get; set; }
        [JsonIgnore]
        public DateTime? DOB { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; } = false;
        [JsonIgnore]
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
