using Intergalactic_Race_League.Models;
using Microsoft.EntityFrameworkCore;

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
        public RacerVehicle GetRacerVehicleById(int id)
        {
            return _context.RacerVehicles
                .Include(rv => rv.Racer)
                .Include(rv => rv.Vehicle)
                .FirstOrDefault(rv => rv.RacerVehicleId == id);
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
        }
        public void AddRacer(Racer racer)
        {
            _context.Racers.Add(racer);
        }
        public void RemoveVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
        }
        public void RemoveRacer(Racer racer)
        {
            _context.Racers.Remove(racer);
        }
        public void RemoveRacerVehicle(RacerVehicle racerVehicle)
        {
            _context.RacerVehicles.Remove(racerVehicle);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
