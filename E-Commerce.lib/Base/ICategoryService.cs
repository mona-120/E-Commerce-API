using E_Commerce.lib.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.lib.Base
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto>? GetByIdAsync(Guid id);
        Task<ResponseDto> AddAsync(CategoryDto entity);
        Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
