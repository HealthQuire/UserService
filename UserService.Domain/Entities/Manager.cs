using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Domain.Entities;

public class Manager
{
    [Column("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Column("userId")]
    public string UserId { get; set; } = null!;
    [Column("medcentreId")]
    public string MedcentreId { get; set; } = null!;
    [Column("firstName")]
    public string FirstName { get; set; } = null!;
    [Column("lastName")]
    public string LastName { get; set; } = null!;
    [Column("fatherName")]
    public string FatherName { get; set; } = null!;
}