namespace UserService.Domain.Entities;

public class Organization
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string OwnerId { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = Guid.NewGuid().ToString();
    public string Status { get; set; } = Guid.NewGuid().ToString();
}