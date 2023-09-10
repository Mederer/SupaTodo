using Microsoft.EntityFrameworkCore;
using SupaTodo.Entities;

namespace SupaTodo.Db
{
    public class SupaTodoContext : DbContext
    {
        public SupaTodoContext(DbContextOptions<SupaTodoContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; } = null!;
    }
}
