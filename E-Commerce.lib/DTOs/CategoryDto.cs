using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.lib.DTOs
{
    public class CategoryDto
    {
        public string? Name { get; set; }
    }
    public class UpdateCategoryDto : CategoryDto
    {
        public Guid CategoryId { get; set; }
    }
}
