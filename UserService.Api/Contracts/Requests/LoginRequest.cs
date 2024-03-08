namespace UserService.Api.Contracts.Requests;

public record LoginRequest(
    string email,
    string password
    );