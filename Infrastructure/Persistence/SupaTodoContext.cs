using Microsoft.EntityFrameworkCore;
using SupaTodo.Domain.Entities;

namespace SupaTodo.Infrastructure.Persistence;

public class SupaTodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; } = null!;

    public SupaTodoContext(DbContextOptions options) : base(options)
    {
    }
}