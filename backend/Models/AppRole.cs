using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class AppRole : IdentityRole
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
