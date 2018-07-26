using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cabify.DataRepository
{
    public static class UseDataRepositoryExtension
    {
        public static IServiceCollection UseDataRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StorefrontContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddTransient<ICartDataReader, CartDataReader>();
            return services;
        }
    }
}
