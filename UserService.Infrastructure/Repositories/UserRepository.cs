using Microsoft.AspNetCore.JsonPatch;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Exceptions;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public List<User> GetUsers() => _context.Users.ToList();
    
    public User? GetUser(string id) =>
        _context.Users.SingleOrDefault(user => user.Id == id);
    
    public User? GetUserByEmail(string email) => 
        _context.Users.SingleOrDefault(user => user.Email == email);

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    
    public void EditUser() =>
        _context.SaveChanges();

    public void DeleteUser(string id)
    {
        var user = GetUser(id);
        if (user == null) throw new NotFoundException("User do not exists");

        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}