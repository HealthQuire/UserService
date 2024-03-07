using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IUserRepository
{
    public List<User> GetUsers();
    public User? GetUser(string id);
    public void AddUser(User user);
}