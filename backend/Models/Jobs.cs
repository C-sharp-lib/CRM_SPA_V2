using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Jobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; } = string.Empty;
        public string JobStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped]
        public string AssignedTo { get; set; }
        [NotMapped]
        public AppUser AssignedToUser { get; set; }
        public string Priority { get; set; }
        [Precision(10,2)]
        public decimal EstimatedCost { get; set; }
        [Precision(10,2)]
        public decimal ActualCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public AppUser CreatedByUser { get; set; }
        [NotMapped]
        public string? LastUpdatedBy { get; set; }
        [NotMapped]
        public AppUser? LastUpdatedByUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
