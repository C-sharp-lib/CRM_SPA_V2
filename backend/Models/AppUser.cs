using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName {  get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public bool? IsActive { get; set; } = false;
        public DateTime? HireDate { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<Jobs> Jobs { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Customers> Customers { get; set; }
    }
}
