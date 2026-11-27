using AutoMapper;
using E_Commerce.db.Base;
using E_Commerce.db.Entities;
using E_Commerce.lib.Base;
using E_Commerce.lib.DTOs;
using E_Commerce.lib.Exceptions;

namespace E_Commerce_API.Services
{
    public class CategoryServices(IGeneralRepo<Category> category_ , IMapper mapper) : ICategoryService
    {
        public async Task<ResponseDto> AddAsync(CategoryDto newCategory)
        {
            try
            {
                var category = mapper.Map<Category>(newCategory);
                var result = await category_.AddAsync(category);
                if (result > 0)
                    return new ResponseDto(true, "Category Added Successfully");
            }catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Server Can't Add Category");
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            try
            {
                var result = await category_.DeleteAsync(id);
                if (result > 0)
                    return new ResponseDto(true, "Category Deleted Successfully");
            }catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Server Can't Delete Category");
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            try
            {
                var categories = await category_.GetAllAsync();
                if (categories == null || !categories.Any())
                    return [];
                var result = mapper.Map<IEnumerable<GetCategoryDto>>(categories);
                return result;
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetCategoryDto?> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await category_.GetByIdAsync(id);
                var result = mapper.Map<GetCategoryDto>(category);
                return result;
            }
            catch
            {
                return new GetCategoryDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateCategoryDto newCategory)
        {
            try
            {
                var category = await category_.GetByIdAsync(newCategory.CategoryId);
                mapper.Map(newCategory, category);
                var result = await category_.UpdateAsync(category);
                if (result > 0)
                    return new ResponseDto(true, "Category Updated Successfully");
            }catch(NotFoundException ex)
            {
                return new ResponseDto(false, ex.Message);
            }catch(Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }

            return new ResponseDto(false, "Server Can't Update Category");
            
        }
    }
}
