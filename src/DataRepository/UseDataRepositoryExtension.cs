using System;
using System.Linq;
using Cabify.DataRepository.Entities;
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

                // NOTE: to simplify, we assume that products' prices are all in € and names in english
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Id = "VOUCHER",
                            Name = "Cabify Voucher",
                            Price = 5.00m
                        },
                        new Product
                        {
                            Id = "TSHIRT",
                            Name = "Cabify T-Shirt",
                            Price = 20.00m
                        },
                        new Product
                        {
                            Id = "MUG",
                            Name = "Cabify Coffee Mug ",
                            Price = 7.50m
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
