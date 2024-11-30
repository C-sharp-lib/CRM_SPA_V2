using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("AspNetRoles")]
    public class AspNetRoles : IdentityRole
    {
        public ICollection<AspNetUserRoles> UserRoles { get; set; }
    }
}
