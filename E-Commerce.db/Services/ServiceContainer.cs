using E_Commerce.db.Context;
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
        public static IServiceCollection AddInjectionOptions(this  IServiceCollection services,IConfiguration config)
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
            return services;
        }
    }
}
