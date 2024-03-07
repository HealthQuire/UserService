namespace UserService.Domain.Entities;

public class Manager
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = Guid.NewGuid().ToString();
}