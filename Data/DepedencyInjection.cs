using Data.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities.Auth;

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

            services.AddIdentityCore<FoodRushIdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AuthDbContext>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ITokenRepository, TokenRepository>();

           

            return services;
        }
    }
}
