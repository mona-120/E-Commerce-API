using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.lib.DTOs
{
    public class ProductDto
    {
        [Required]
        public string? Name { get; set; }
        [MaxLength(200, ErrorMessage = "Max Description is 200 char")]
        [Required]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string? ProductImage { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }

    public class UpdateProductDto : ProductDto
    {
        public Guid Id { get; set; }
    }
    public class GetProductDto : ProductDto
    {
        public Guid Id { get; set; }
        //Don't use GetCategoryDto to avoid Circular Refrence Problem
        public string? CategoryName { get; set; }
    }
}
