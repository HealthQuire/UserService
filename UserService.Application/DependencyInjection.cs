using UserService.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Helpers;
using UserService.Application.Services.Auth;

namespace UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, Services.User.UserService>();
        services.AddScoped<IAuthService, AuthService>();
        
        services.AddAutoMapper(typeof(MappingProfiles));
        
        return services;
    }
}