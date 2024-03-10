using Microsoft.AspNetCore.JsonPatch;
using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IUserRepository
{
    public List<User> GetUsers();
    public User? GetUser(string id);
    public User? GetUserByEmail(string email);
    public void AddUser(User user);
    public void EditUser();
    public void DeleteUser(User user);
}