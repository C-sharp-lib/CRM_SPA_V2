using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    [Table("JobUserTasks")]
    public class JobUserTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobUserTaskId { get; set; }
        [ForeignKey("JobId")]
        public int JobId { get; set; }
        public Jobs Job { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }
        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
    }
}
