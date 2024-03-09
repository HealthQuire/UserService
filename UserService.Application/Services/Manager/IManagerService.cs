using Microsoft.AspNetCore.JsonPatch;

namespace UserService.Application.Services.Manager;

public interface IManagerService
{
    public List<Domain.Entities.Manager> GetManagers();

    public Domain.Entities.Manager GetManager(string id);
    
    public Domain.Entities.Manager AddManager(
        string userId,
        string medcentreId,
        string firstName,
        string lastName,
        string fatherName
    );

    public Domain.Entities.Manager EditManager(string id, JsonPatchDocument<Domain.Entities.Manager> patchDoc);

    public void DeleteManager(string id);
}