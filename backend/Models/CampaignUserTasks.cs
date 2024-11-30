using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    [Table("CampaignUserTasks")]
    public class CampaignUserTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CampaignUserTaskId { get; set; }
        [ForeignKey("CampaignId")]
        public int CampaignId { get; set; }
        public Campaigns Campaign {  get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }
        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        public Tasks Task {  get; set; }
    }
}
