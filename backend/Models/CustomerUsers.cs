﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    [Table("CustomerUsers")]
    public class CustomerUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerUsersId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public AppUsers User { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
    }
}
