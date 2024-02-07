using Application.Interface;
using Application.Interface.Common;
using Infrastructure.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistances.Contexts;
using Persistances.Repositories;

namespace Infrastructure.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IHost MigrateDatabase(this IHost host )
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();

                }
                catch (Exception ex)
                {
                    // Log the error or handle it as needed
                    Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
                    throw;
                }
            }

            return host;
        }

        public static IServiceCollection AddInfrastructure( this IServiceCollection services,IConfiguration configuration )
        {
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlite(configuration.GetConnectionString("Database"));
                op.EnableSensitiveDataLogging();
            });
            
          
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        
            return services;
        }
    };
    public static class MigrationSetup
    {
        public static IHost MigrateDatabase( this IHost host )
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();
                   
                }
                catch (Exception ex)
                {
                    // Log the error or handle it as needed
                    Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
                    throw;
                }
            }

            return host;
        }
    
    }
}
