using Microsoft.EntityFrameworkCore;
using RpgGame.Domain.Entities;

namespace RpgGame.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<HeroBattle> HeroesBattles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weapon>().HasKey(w => w.Id);
            modelBuilder.Entity<Weapon>().Property(w => w.HeroId);
            modelBuilder
                .Entity<Weapon>()
                .HasOne(x => x.Hero)
                .WithMany()
                .HasForeignKey(x => x.HeroId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<HeroBattle>().HasKey(x => new { x.HeroId, x.BattleId });

            modelBuilder.Entity<HeroBattle>().Property(x => x.BattleId).IsRequired();
            modelBuilder.Entity<HeroBattle>().Property(x => x.HeroId).IsRequired();

            modelBuilder
                .Entity<HeroBattle>()
                .HasOne(x => x.Battle)
                .WithMany()
                .HasForeignKey(x => x.BattleId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder
                .Entity<HeroBattle>()
                .HasOne(x => x.Hero)
                .WithMany()
                .HasForeignKey(x => x.HeroId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
