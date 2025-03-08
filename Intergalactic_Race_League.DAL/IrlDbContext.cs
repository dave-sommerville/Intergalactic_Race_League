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
        public DbSet<RacerVehicle> RacerVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Primary Keys
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.VehicleId);
            modelBuilder.Entity<Racer>()
                .HasKey(r => r.RacerId);
            modelBuilder.Entity<RacerVehicle>()
                .HasKey(rv => rv.RacerVehicleId);
            modelBuilder.Entity<Race>()
                .HasKey(r => r.RaceId);
            modelBuilder.Entity<Tournament>()
                .HasKey(r => r.TournamentId);
            //  Relationships
            //  One-to-many: Tournament <-> Race (starting and finishing)
            modelBuilder.Entity<Tournament>()
                .HasMany(t => t.AllRaces)
                .WithOne(r => r.Tournament)
                .HasForeignKey(r => r.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tournament>()
            .HasMany(t => t.RankedRaces)
            .WithOne(r => r.Tournament)
            .HasForeignKey(r => r.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);
            //  Two RacerVehicles per race
            modelBuilder.Entity<Race>()
                .HasOne(r => r.RacerOne)
                .WithMany()
                .HasForeignKey(r => r.RacerOneID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Race>()
                .HasOne(r => r.RacerOne)
                .WithMany()
                .HasForeignKey(r => r.RacerOneID)
                .OnDelete(DeleteBehavior.Restrict);
            //  One-to-one: Race <-> RacerVehicle
            modelBuilder.Entity<Racer>()
                .HasOne(r => r.RacerVehicle)
                .WithOne(rv => rv.Racer)
                .HasForeignKey<RacerVehicle>(rv => rv.RacerId)
                .OnDelete(DeleteBehavior.Cascade);
            //  Property Contraints
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Type)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Racer>()
                .Property(r => r.DriverName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Racer>()
                .Property(r => r.DriverAge);
            modelBuilder.Entity<Racer>()
                .Property(r => r.DriverHeightInCm)
                .IsRequired();
            modelBuilder.Entity<Racer>()
                .Property(r => r.DriverCountry)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Race>()
                .Property(r => r.RaceName)
                .IsRequired();
            modelBuilder.Entity<Race>()
                .Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Race>()
                .Property(r => r.TimeStamp);
            modelBuilder.Entity<Race>()
                .Property(r => r.Winner);
            modelBuilder.Entity<Tournament>()
                .Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Tournament>()
                .Property(t => t.TimeStamp);
            // The Lists?? 
        }
    }
}
