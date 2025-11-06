using Microsoft.EntityFrameworkCore;
using nerdier.Model;

namespace nerdier.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Player { get; set; }
    }
}

