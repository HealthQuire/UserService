using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Exceptions;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public static class MockedUserRepo
{
    public static readonly List<User> _repo = new();
}

public class UserRepository : IUserRepository
{
    // private readonly DataContext _context;
    //
    // public UserRepository(DataContext context)
    // {
    //     _context = context;
    // }

    public List<User> GetUsers() => MockedUserRepo._repo.ToList();
    
    public User GetUser(string id)
    {
        var user = MockedUserRepo._repo.SingleOrDefault(user => user.Id == id);
        
        if (user is null) throw new NotFoundException("User do not exists");

        return user;
    }
    
    public User GetUserByEmail(string email)
    {
        var user = MockedUserRepo._repo.SingleOrDefault(user => user.Email == email);
        
        if (user is null) throw new NotFoundException("User do not exists");

        return user;
    }
    
    public void AddUser(User user) => MockedUserRepo._repo.Add(user);
}