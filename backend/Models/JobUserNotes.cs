using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    [Table("JobUserNotes")]
    public class JobUserNotes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobUserNoteId { get; set; }
        [ForeignKey("JobId")]
        public int JobId { get; set; }
        public Jobs Job {  get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public AppUsers User { get; set; }
        [ForeignKey("NoteId")]
        public int NoteId { get; set; }
        public Notes Notes { get; set; }
    }
}
