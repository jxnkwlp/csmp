using CSMP.Portal.Domains;
using Microsoft.EntityFrameworkCore;

namespace CSMP.Portal.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<SecurityToken> SecurityTokens { get; set; }

        public DbSet<Snapshot> Snapshots { get; set; }

        public DbSet<Agent> Agents { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
