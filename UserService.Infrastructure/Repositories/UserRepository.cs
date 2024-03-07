using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Exceptions;

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

    public List<User> GetUsers()
    {
        return MockedUserRepo._repo.ToList();
    }   
    
    public User GetUser(string id)
    {
        var user = MockedUserRepo._repo.SingleOrDefault(user => user.Id == id);
        
        if (user is null) throw new NotFoundException("User do not exists");

        return user;
    }
    
    public void AddUser(User user)
    {
        MockedUserRepo._repo.Add(user);
    }
}