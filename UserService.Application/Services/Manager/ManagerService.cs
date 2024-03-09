using Microsoft.AspNetCore.JsonPatch;
using UserService.Application.Interfaces;
using UserService.Domain.Exceptions;

namespace UserService.Application.Services.Manager;

public class ManagerService : IManagerService
{
    private readonly IManagerRepository _repository;

    public ManagerService(IManagerRepository repository)
    {
        _repository = repository;
    }
    
    public List<Domain.Entities.Manager> GetManagers()
    {
        var managers = _repository.GetManagers();
    
        return managers;
    }

    public Domain.Entities.Manager GetManager(string id)
    {
        var manager = _repository.GetManager(id);
        if (manager == null) throw new NotFoundException("Manager do not exists");

        return manager;
    }

    // TODO
    public Domain.Entities.Manager AddManager(
        string userId,
        string medcentreId,
        string firstName,
        string lastName,
        string fatherName
    )
    {
        return new Domain.Entities.Manager();
    }

    // TODO
    public Domain.Entities.Manager EditManager(string id, JsonPatchDocument<Domain.Entities.Manager> patchDoc)
    {
        return new Domain.Entities.Manager();
    }

    // TODO
    public void DeleteManager(string id)
    {
        
    }
}