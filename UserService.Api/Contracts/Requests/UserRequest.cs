namespace UserService.Api.Contracts.Requests;

public record UserRequest(
    string email,
    string password,
    int role,
    string phone,
    string avatarUrl,
    string status
);