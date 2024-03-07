using UserService.Application.Dtos;

namespace UserService.Application.Services.User;

public interface IUserService
{
    public List<UserDto> GetUsers();
    public UserDto GetUser(string id);
    public UserDto AddUser(
        string email,
        string password,
        int role,
        string phone,
        string avatarUrl,
        string status
        );
}