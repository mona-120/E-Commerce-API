using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.db.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is Requird")]
        [MaxLength(50,ErrorMessage ="Max Product Name is 50 char")]
        public string? Name { get; set; }
        [MaxLength(200,ErrorMessage = "Max Description is 200 char")]
        public string? Description { get; set; }
        [Column(TypeName ="decimal(16,4)")]
        public decimal? Price { get; set; }
        public string? ProductImage { get; set; }
        public int? Quantity { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
