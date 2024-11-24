﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class LeadHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadHistoryId { get; set; }
        public int LeadId { get; set; }
        public Leads Lead { get; set; }
        public string UpdatedBy { get; set; }
        public AppUser UpdatedByUser { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FieldChanged { get; set; }
        public string OldValue { get; set; }
    }
}