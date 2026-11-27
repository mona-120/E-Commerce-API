using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.db.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } 
        [Required(ErrorMessage = "Name is Requird")]
        [MaxLength(50, ErrorMessage = "Max Category Name is 50 char")]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
