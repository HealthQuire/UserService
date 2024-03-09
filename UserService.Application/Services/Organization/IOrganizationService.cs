using Microsoft.AspNetCore.JsonPatch;

namespace UserService.Application.Services.Organization;

public interface IOrganizationService
{
    public List<Domain.Entities.Organization> GetOrganizations();
    
    public Domain.Entities.Organization GetOrganization(string id);
    
    public Domain.Entities.Organization AddOrganization(
        string ownerId,
        string name,
        string status
    );

    public Domain.Entities.Organization EditOrganization(
        string id,
        JsonPatchDocument<Domain.Entities.Organization> patchDoc
    );
    
    public void DeleteOrganization(string id);
}