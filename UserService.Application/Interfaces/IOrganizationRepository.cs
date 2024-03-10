using Microsoft.AspNetCore.JsonPatch;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IOrganizationRepository
{
    public List<Organization> GetOrganizations();
    public Organization? GetOrganization(string id);
    public Organization? GetOrganizationByName(string name);
    public void AddOrganization(Organization user);
    public void EditOrganization();
    public void DeleteOrganization(Organization organization);
}