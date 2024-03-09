using Microsoft.OpenApi.Models;

namespace UserService.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "HealthQuire.UserService",
                Contact = new OpenApiContact
                {
                    Name = "Almaz Tazeev",
                    Url = new Uri("https://github.com/aaalace")
                }
            });
        });
        services.AddControllers()
            .AddNewtonsoftJson();   

        return services;
    }
}