using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Domain.Entities;

public class Organization
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Column("ownerId")]
    public string OwnerId { get; set; } = Guid.NewGuid().ToString();
    [Column("name")]
    public string Name { get; set; } = Guid.NewGuid().ToString();
    [Column("status")]
    public string Status { get; set; } = Guid.NewGuid().ToString();
}