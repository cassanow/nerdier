using Microsoft.EntityFrameworkCore;

namespace nerdier.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}

