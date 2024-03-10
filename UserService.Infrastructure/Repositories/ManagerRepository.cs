using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly DataContext _context;

    public ManagerRepository(DataContext context) =>
        _context = context;
    
    public List<Manager> GetManagers() => 
        _context.Managers.ToList();

    public Manager? GetManager(string id) =>
        _context.Managers.SingleOrDefault(manager => manager.Id == id);

    public void AddManager(Manager manager)
    {
        _context.Managers.Add(manager);
        _context.SaveChanges();
    }

    public void EditManager() =>
        _context.SaveChanges();

    public void DeleteManager(Manager manager)
    {
        _context.Managers.Remove(manager);
        _context.SaveChanges();
    }
}