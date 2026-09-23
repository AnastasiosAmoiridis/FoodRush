using Models.Options.Auth;

namespace FoodRush.Options
{
    public static class OptionsRegistration
    {
        public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<JWTOptions>().Bind(configuration.GetSection(AuthOptions.Auth).GetSection(JWTOptions.JWT));

            services.AddOptions<AuthOptions>().Bind(configuration.GetSection(AuthOptions.Auth));

            return services;
        }
    }
}
