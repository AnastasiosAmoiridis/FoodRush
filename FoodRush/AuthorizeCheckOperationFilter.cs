using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FoodRush
{
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check if endpoint has [Authorize] attribute
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                  .OfType<AuthorizeAttribute>().Any()
                              || context.MethodInfo.GetCustomAttributes(true)
                                  .OfType<AuthorizeAttribute>().Any();

            if (!hasAuthorize)
                return;

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IOpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your JWT token",
                Required = false
            });
        }
    }
}
