using E_Commerce.lib.Base;
using E_Commerce_API.Services;

namespace E_Commerce_API.Classes
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionsApi(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService, CategoryServices>();
            return services;
        }
    }
}
