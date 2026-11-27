using AutoMapper;
using E_Commerce.db.Base;
using E_Commerce.db.Entities;
using E_Commerce.lib.Base;
using E_Commerce.lib.DTOs;
using E_Commerce.lib.Exceptions;
namespace E_Commerce_API.Services
{
    public class ProductServices(IGeneralRepo<Product> product_, IMapper mapper) : IProductService
    {
        public async Task<ResponseDto> AddAsync(ProductDto dto)
        {
            try
            {
                var product = mapper.Map<Product>(dto);
                int result = await product_.AddAsync(product); // SaveChangesAsync return number of changed rows
                if(result > 0)
                {
                    return new ResponseDto(true, "Product Added Successfully!");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Server Can't save!");
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            try
            {
                var result = await product_.DeleteAsync(id);
                if(result > 0)
                {
                    return new ResponseDto(true, "Product Deleted Successfully!");
                }
            }catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Server can't delete!");
        }

        public async Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
            try
            {
                var products = await product_.GetAllAsync();
                if (products == null || !products.Any())
                    return [];

                var productsDto = mapper.Map<IEnumerable<GetProductDto>>(products);
                return productsDto;
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetProductDto> GetByIdAsync(Guid id)
        {
            try
            {
                var product = await product_.GetByIdAsync(id);

                var productDto = mapper.Map<GetProductDto>(product);
                return productDto;
            }
            catch
            {
                return new GetProductDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await product_.GetByIdAsync(updateProductDto.ProductId);

                mapper.Map(updateProductDto,product);

                int result = await product_.UpdateAsync(product);
                if (result > 0)
                    return new ResponseDto(true, "Product Updated Successfully!");
            }
            catch (NotFoundException ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            
            return new ResponseDto(false, "Server Can't update!");
        }
    }
}
