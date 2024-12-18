﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UPC { get; set; }
        public string? Description { get; set; } = string.Empty;
        [Required]
        [Precision(10, 2)]
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        [Required]
        public int QuantityInStock { get; set; } = 0;
        public string? Category { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
    }
}
