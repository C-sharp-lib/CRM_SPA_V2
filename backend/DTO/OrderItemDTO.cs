using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class OrderItemDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Precision(10, 2)]
        public decimal UnitPrice { get; set; }
        [Precision(10, 2)]
        public decimal TotalPrice { get; set; }
    }
}
