using Microsoft.AspNetCore.JsonPatch;
using UserService.Application.Interfaces;
using UserService.Domain.Exceptions;

namespace UserService.Application.Services.Organization;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _repository;
    
    public OrganizationService(IOrganizationRepository repository)
    {
        _repository = repository;
    }

    public List<Domain.Entities.Organization> GetOrganizations()
    {
        var organizations = _repository.GetOrganizations();

        return organizations;
    }

    public Domain.Entities.Organization GetOrganization(string id)
    {
        var organization = _repository.GetOrganization(id);
        if (organization == null) throw new NotFoundException("Organization do not exists");

        return organization;
    }

    public Domain.Entities.Organization AddOrganization(
        string ownerId,
        string name,
        string status
    )
    {
        var organization = _repository.GetOrganizationByName(name);
        if (organization != null) throw new Exception("Organization with this name is already exists");

        var newOrganization = new Domain.Entities.Organization()
        {
            OwnerId = ownerId,
            Name = name,
            Status = status
        };
        
        _repository.AddOrganization(newOrganization);

        return newOrganization;
    }

    public Domain.Entities.Organization EditOrganization(
        string id,
        JsonPatchDocument<Domain.Entities.Organization> patchDoc
    )
    {
        var organization = _repository.GetOrganization(id);
        if (organization == null) throw new NotFoundException("Organization do not exists");
        
        patchDoc.ApplyTo(organization);
        
        _repository.EditOrganization();

        return organization;
    }

    public void DeleteOrganization(string id)
    {
        _repository.DeleteOrganization(id);
    }
}