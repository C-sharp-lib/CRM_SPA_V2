using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public DateTime OrderDate { get; set; }
        [Precision(10,2)]
        public decimal TotalAmount { get; set; }
        [Precision(10,2)]
        public decimal DiscountAmount { get; set; }
        [Precision(10, 2)]
        public decimal NetAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Notes {  get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public AppUser LastUpdatedByUser { get; set; }
    }
}
