using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class UserDTO : AppUsers
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public bool? IsActive { get; set; } = false;
        [Required]
        public DateTime? HireDate { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
    }
}
