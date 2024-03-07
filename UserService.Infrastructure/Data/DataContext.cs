using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Manager> Managers { get; set; } = null!;
    public DbSet<Organization> Organizations { get; set; } = null!;
}