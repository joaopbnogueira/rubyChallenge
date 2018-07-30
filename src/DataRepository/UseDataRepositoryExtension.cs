using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cabify.DataRepository
{
    public static class UseDataRepositoryExtension
    {
        public static IServiceCollection UseDataRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StorefrontContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDataReader, DataReader>();
            services.AddScoped<IDataWriter, DataWriter>();
            return services;
        }

        public static void InitializeDataRepository(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StorefrontContext>();                
                context.Database.Migrate();
            }
        }
    }
}
