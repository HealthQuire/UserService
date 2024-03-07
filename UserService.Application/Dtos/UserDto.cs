namespace UserService.Application.Dtos;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Role { get; set; }
    public string Phone { get; set; } = null!;
    public string AvatarUrl { get; set; } = null!;
    public string Status { get; set; } = null!;
}