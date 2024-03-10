namespace UserService.Api.Contracts.Responses;

public record ManagerResponse(
    string id,
    string userid,
    string medcentreid,
    string firstname,
    string lastname,
    string fathername,
    string email,
    int role,
    string phone,
    string avatarUrl,
    string status
    );