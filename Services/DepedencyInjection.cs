using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace Services
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(DepedencyInjection));

            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<ICodeDefinitionService, CodeDefinitionService>();

            return services;
        }
    }
}
