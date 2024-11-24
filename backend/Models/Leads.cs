using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Leads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadId { get; set; }
        public string Source { get; set; }
        public string AssignedTo { get; set; }
        public AppUser AssignedToUser { get; set; }
        public string Status { get; set; }
        public string CustomerId { get; set; }
        public Customers Customer { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string LeadSource { get; set; }
        public string UpdatedBy { get; set; }
        public AppUser UpdatedByUser { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
