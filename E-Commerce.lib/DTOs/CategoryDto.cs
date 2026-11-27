using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.lib.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string? Name { get; set; }
    }
    public class UpdateCategoryDto : CategoryDto
    {
        public Guid CategoryId { get; set; }
    }
    public class GetCategoryDto : CategoryDto
    {
        public Guid CategoryId { get; set; }
        public ICollection<GetProductDto>? Products { get; set; }
    }
}
