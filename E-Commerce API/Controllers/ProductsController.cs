using E_Commerce.lib.Base;
using E_Commerce.lib.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await productService.GetAllAsync();
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await productService.GetByIdAsync(id);
            return result != null && result.ProductId != Guid.Empty? Ok(result) : NotFound(id);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            var result = await productService.AddAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto product)
        {
            var result = await productService.UpdateAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await productService.DeleteAsync(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}
