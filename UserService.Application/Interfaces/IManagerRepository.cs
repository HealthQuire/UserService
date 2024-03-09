using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IManagerRepository
{
    public List<Manager> GetManagers();
    public Manager? GetManager(string id);
    public void AddManager(Manager manager);
    public void EditManager();
    public void DeleteManager(string id);
}