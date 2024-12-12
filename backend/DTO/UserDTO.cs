using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class UserDTO
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public bool? IsActive { get; set; } = false;
        public DateTime? HireDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class CreateUserDTO : AppUsers
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
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
    }
}
