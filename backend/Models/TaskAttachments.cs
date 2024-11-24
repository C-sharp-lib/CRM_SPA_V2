using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TaskAttachments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskAttachmentId { get; set; }
        public int TaskId { get; set; }
        public Tasks Task { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string UploadedBy { get; set; }
        public AppUser UploadedByUser { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
