using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FoodRushDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
