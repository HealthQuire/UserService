namespace UserService.Api.Contracts.Requests;

public record OrganizationRequest(
    string ownerId,
    string name,
    string status = ""
    );