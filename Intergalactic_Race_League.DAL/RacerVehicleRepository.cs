using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.DAL
{
    public class RacerVehicleRepository
    {
        private readonly IrlDbContext _context;
        public RacerVehicleRepository(IrlDbContext context)
        {
            _context = context;
        }
        public List<RacerVehicle> GetAllRacerVehicles()
        {
            return _context.RacerVehicles.ToList();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
        }
        public void AddRacer(Racer racer)
        {
            _context.Racers.Add(racer);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
