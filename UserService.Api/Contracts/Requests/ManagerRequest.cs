namespace UserService.Api.Contracts.Requests;

public record ManagerRequest(
    string email,
    string password,
    int role,
    string medcentreId,
    string firstName,
    string lastName,
    string fatherName = "",
    string phone = "",
    string avatarUrl = "",
    string status = ""
    );