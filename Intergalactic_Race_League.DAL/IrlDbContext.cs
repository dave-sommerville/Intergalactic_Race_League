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

        }
    }
}
