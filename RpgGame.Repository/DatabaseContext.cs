using Microsoft.EntityFrameworkCore;
using RpgGame.Domain.Entities;

namespace RpgGame.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
