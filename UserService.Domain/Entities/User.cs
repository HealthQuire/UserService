namespace UserService.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Column("email")]
    public string Email { get; set; } = null!;
    [Column("password")]
    public string Password { get; set; } = null!;
    [Column("role")]
    public int Role { get; set; }
    [Column("phone")]
    public string Phone { get; set; } = null!;
    [Column("avatarUrl")]
    public string AvatarUrl { get; set; } = null!;
    [Column("status")]
    public string Status { get; set; } = null!;
}