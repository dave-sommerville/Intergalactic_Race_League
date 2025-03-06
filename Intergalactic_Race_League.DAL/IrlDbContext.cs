using Microsoft.EntityFrameworkCore;
using Intergalactic_Race_League.Models;
using Microsoft.Identity.Client;

namespace Intergalactic_Race_League.DAL
{
    public class IrlDbContext : DbContext
    {
        public IrlDbContext(DbContextOptions<IrlDbContext> options) : base(options) {   }
        public DbSet<Racer> Racers { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResult> RaceResult { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaceParticipant>()
                .HasKey(rp => new { rp.RaceId, rp.RacerId });
            modelBuilder.Entity<RaceParticipant>()
                .HasOne(rp => rp.Race)
                .WithMany(r => r.RaceParticipants)
                .HasForeignKey(rp => rp.RaceId);
            modelBuilder.Entity<RaceParticipant>()
                .HasOne(rp => rp.Racer)
                .WithMany(r => r.RaceParticipants)
                .HasForeignKey(rp => rp.RacerId);

            modelBuilder.Entity<Racer>()
                .HasOne(r => r.Vehicle)
                .WithOne(v => v.Racer)
                .HasForeignKey<Vehicle>(v => v.RacerId);
            modelBuilder.Entity<Race>()
                .HasOne(r => r.Tournament)
                .WithMany(t => t.Races)
                .HasForeignKey(r => r.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
