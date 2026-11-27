using AutoMapper;
using E_Commerce.db.Entities;
using E_Commerce.lib.DTOs;

namespace E_Commerce_API.Classes
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
