using UserService.Application.Dtos;

namespace UserService.Application.Services.Auth;

public interface IAuthService
{
    public UserDto Login(string email, string password);
}