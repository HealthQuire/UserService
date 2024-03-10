using Microsoft.AspNetCore.JsonPatch;
using UserService.Domain.Entities;

namespace UserService.Api.Contracts.Requests;

public record EditManagerRequest(
    JsonPatchDocument<User> patchUserDoc,
    JsonPatchDocument<Manager> patchManagerDoc
);