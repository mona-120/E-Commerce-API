using E_Commerce.lib.Base;
using E_Commerce.lib.DTOs;

namespace E_Commerce_API.Services
{
    public class CategoryServices : ICategoryService
    {
        public Task<ResponseDto> AddAsync(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCategoryDto>? GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
