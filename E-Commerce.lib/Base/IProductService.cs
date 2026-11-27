using E_Commerce.lib.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.lib.Base
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllAsync();
        Task<GetProductDto>? GetByIdAsync(Guid id);
        Task<ResponseDto> AddAsync(ProductDto entity);
        Task<ResponseDto> UpdateAsync(UpdateProductDto entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
