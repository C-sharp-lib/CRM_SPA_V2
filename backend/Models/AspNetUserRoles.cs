using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRoles : IdentityUserRole<string>
    {
        public AspNetUsers User { get; set; }
        public AspNetRoles Role { get; set; }
    }
}
