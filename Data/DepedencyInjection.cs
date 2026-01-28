using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, string appConnectionString, string authConnectionString)
        {
            services.AddDbContext<FoodRushDbContext>(options =>
            {
                options.UseSqlServer(appConnectionString);
            });

            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(authConnectionString);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
