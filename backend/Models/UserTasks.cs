using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class UserTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public Tasks Task {  get; set; }
        public string UserId { get; set; }
        public AppUsers User { get; set; }
    }
}
