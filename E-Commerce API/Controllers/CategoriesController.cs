using E_Commerce.lib.Base;
using E_Commerce.lib.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await categoryService.GetAllAsync();
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await categoryService.GetByIdAsync(id);
            return result != null && result.CategoryId != Guid.Empty? Ok(result) : NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            var result = await categoryService.AddAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
        {
            var result = await categoryService.UpdateAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await categoryService.DeleteAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}
