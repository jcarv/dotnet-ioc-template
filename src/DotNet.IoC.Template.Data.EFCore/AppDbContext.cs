namespace DotNet.IoC.Template.Data.EFCore
{
    using DotNet.IoC.Template.Data.EFCore.Mappings;
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<TeamsPlayers> TeamsPlayers { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new PlayerMapping());
            modelBuilder.ApplyConfiguration(new TeamMapping());
            modelBuilder.ApplyConfiguration(new TeamsPlayersMapping());
        }
    }
}
