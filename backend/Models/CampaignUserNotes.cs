﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class CampaignUserNotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CampaignUserNoteId { get; set; }
        public int CampaignId { get; set; }
        public Campaigns Campaign {  get; set; }
        public string UserId { get; set; }
        public AppUsers User { get; set; }
        public int NoteId { get; set; }
        public Notes Notes {  get; set; }
    }
}
