using UserService.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Helpers;
using UserService.Application.Services.Auth;
using UserService.Application.Services.Manager;
using UserService.Application.Services.Organization;

namespace UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, Services.User.UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<IManagerService, ManagerService>();
        
        services.AddAutoMapper(typeof(MappingProfiles));
        
        return services;
    }
}