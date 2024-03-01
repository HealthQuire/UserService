namespace UserService.Contracts.Organizations;

public record GetResponse(
    int id,
    int ownerId,
    string name,
    string status
    );