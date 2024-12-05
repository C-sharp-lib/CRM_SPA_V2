using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("AspNetRoles")]
    public class AppRoles : IdentityRole
    {
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
