﻿using System.ComponentModel.DataAnnotations.Schema;
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
        public string? ImageUrl { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string TruncateWords(string text, int wordCount = 5)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length <= wordCount) return text;
            return string.Join(" ", words.Take(wordCount)) + "...";
        }
    }
}
