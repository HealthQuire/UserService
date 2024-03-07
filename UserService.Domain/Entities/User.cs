namespace UserService.Domain.Entities;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; }
    public string Phone { get; set; } = null!;
    public string AvatarUrl { get; set; } = null!;
    public string Status { get; set; } = null!;
}