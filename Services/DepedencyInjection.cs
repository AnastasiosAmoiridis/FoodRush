using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {           
            return services;
        }
    }
}
