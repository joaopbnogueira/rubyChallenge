using Microsoft.Extensions.DependencyInjection;

namespace Cabify.DataRepository
{
    public static class UseDataRepositoryExtension
    {
        public static IServiceCollection UseDataRepository(this IServiceCollection services)
        {
            services.AddTransient<ICartDataReader, CartDataReader>();
            return services;
        }
    }
}
