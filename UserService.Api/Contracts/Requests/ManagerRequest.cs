namespace UserService.Api.Contracts.Requests;

public record ManagerRequest(
    UserRequest user,
    string medcentreId,
    string firstName,
    string lastName,
    string fatherName
    );