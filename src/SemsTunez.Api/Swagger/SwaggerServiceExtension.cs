using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SemsTunez.Api.Swagger;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SemsTunez Api",
                Version = "v1"
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Description = "Enter: Bearer {your JWT token}"
            });


            c.OperationFilter<AuthorizeOperationFilter>();
        });

        return services;
    }
}
