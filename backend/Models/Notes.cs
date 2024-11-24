using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        public string Note {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
