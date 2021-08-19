using Microsoft.EntityFrameworkCore;

namespace TucDatabaseFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }



        public DbSet<HockeyPlayer> Players { get; set; }
    }
}