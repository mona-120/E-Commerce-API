using E_Commerce.lib.Base;
using E_Commerce_API.Services;

namespace E_Commerce_API.Classes
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptions(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService, CategoryServices>();
            return services;
        }
    }
}
