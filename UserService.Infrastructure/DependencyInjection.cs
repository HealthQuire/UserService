using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Data;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        
        // services.AddDbContext<DataContext>(options =>
        // {
        //     options.UseNpgsql(connectionString);
        // });

        return services;
    }
}