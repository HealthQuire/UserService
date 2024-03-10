using Microsoft.AspNetCore.JsonPatch;
using UserService.Application.Interfaces;
using UserService.Domain.Exceptions;

namespace UserService.Application.Services.Manager;

public class ManagerService : IManagerService
{
    private readonly IManagerRepository _managerRepository;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IUserRepository _userRepository;
    
    public ManagerService(
        IManagerRepository managerRepository, 
        IOrganizationRepository organizationRepository,
        IUserRepository userRepository)
    {
        _managerRepository = managerRepository;
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
    }
    
    public List<Domain.Entities.Manager> GetManagers()
    {
        var managers = _managerRepository.GetManagers();
    
        return managers;
    }

    public Domain.Entities.Manager GetManager(string id)
    {
        var manager = _managerRepository.GetManager(id);
        if (manager == null) throw new NotFoundException("Manager do not exists");

        return manager;
    }
    
    public Domain.Entities.Manager AddManager(
        string userId,
        string medcentreId,
        string firstName,
        string lastName,
        string fatherName
    )
    {
        var organization = _organizationRepository.GetOrganization(medcentreId);
        if (organization == null) throw new NotFoundException("Med centre with this id do not exists");

        var newManager = new Domain.Entities.Manager()
        {
            UserId = userId,
            MedcentreId = medcentreId,
            FirstName = firstName,
            LastName = lastName,
            FatherName = fatherName
        };
        
        _managerRepository.AddManager(newManager);
        
        return newManager;
    }

    // TODO
    public Domain.Entities.Manager EditManager(string id, JsonPatchDocument<Domain.Entities.Manager> patchDoc)
    {
        var manager = _managerRepository.GetManager(id);
        if (manager == null) throw new NotFoundException("Manager do not exists");
        
        patchDoc.ApplyTo(manager);

        var organization = _organizationRepository.GetOrganization(manager.MedcentreId);
        if (organization == null) throw new NotFoundException("Med centre with this id do not exists");
        var user = _userRepository.GetUser(manager.UserId);
        if (user == null) throw new NotFoundException("User with this id do not exists");
        
        _managerRepository.EditManager();
        
        return manager;
    }
    
    public void DeleteManager(string id)
    {
        var manager = _managerRepository.GetManager(id);
        if (manager == null) throw new NotFoundException("Manager do not exists");
        
        _managerRepository.DeleteManager(manager);
    }
}