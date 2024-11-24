using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class JobDTO
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; } = string.Empty;
        [Required]
        public string JobStatus { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal EstimatedCost { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal ActualCost { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string LastUpdatedBy { get; set; } = String.Empty;
        [Required]
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
