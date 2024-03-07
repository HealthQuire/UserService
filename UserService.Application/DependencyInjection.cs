using Microsoft.AspNetCore.Identity;
using UserService.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Helpers;

namespace UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, Services.User.UserService>();
        
        services.AddAutoMapper(typeof(MappingProfiles));
        
        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequiredUniqueChars = 0;
        });

        return services;
    }
}