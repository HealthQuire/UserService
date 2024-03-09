using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly DataContext _context;

    public ManagerRepository(DataContext context)
    {
        _context = context;
    }
    
    public List<Manager> GetManagers()
    {
        return new List<Manager>();
    }

    public Manager? GetManager(string id)
    {
        return new Manager();
    }

    public void AddManager(Manager manager)
    {
        
    }

    public void EditManager()
    {
        
    }

    public void DeleteManager(string id)
    {
        
    }
}