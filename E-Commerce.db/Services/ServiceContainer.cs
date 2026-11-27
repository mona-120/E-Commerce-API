using E_Commerce.db.Base;
using E_Commerce.db.Context;
using E_Commerce.db.Entities;
using E_Commerce.db.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.db.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionsDb(this  IServiceCollection services,IConfiguration config)
        {
            string constr = "constr";
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString(constr),
                      sqlOptions =>
                      {
                          sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly);
                          sqlOptions.EnableRetryOnFailure();
                      }
                      ),
                       ServiceLifetime.Scoped
                      );
            services.AddScoped<IGeneralRepo<Product>, GeneralRepo<Product>>();
            services.AddScoped<IGeneralRepo<Category>, GeneralRepo<Category>>();
            return services;
        }
    }
}
