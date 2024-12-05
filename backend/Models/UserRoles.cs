using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("AspNetUserRoles")]
    public class UserRoles : IdentityUserRole<string>
    {
        public AppUsers User { get; set; }
        public AppRoles Role { get; set; }
    }
}
