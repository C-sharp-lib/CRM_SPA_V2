using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string UPC {  get; set; }
        public string? Description { get; set; } = string.Empty;
        [Precision(10,2)]
        public decimal? Price { get; set; }
        public string? Currency {  get; set; }
        public int QuantityInStock { get; set; } = 0;
        public string? Category {  get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
