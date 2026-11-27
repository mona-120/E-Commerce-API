using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.lib.DTOs
{
    public class ProductDto
    {
        public string? Name { get; set; }
        [MaxLength(200, ErrorMessage = "Max Description is 200 char")]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ProductImage { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class UpdateProductDto : ProductDto
    {
        public Guid ProductId { get; set; }
    }
    public class GetProductDto : ProductDto
    {
        public Guid ProductId { get; set; }
        //Don't use GetCategoryDto to avoid Circular Refrence Problem
        public string? CategoryName { get; set; }
    }
}
