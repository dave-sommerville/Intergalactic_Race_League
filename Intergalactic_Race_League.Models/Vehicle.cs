namespace Intergalactic_Race_League.Models
{
    public class Vehicle
    {
        private static int _nextId;
        public int VehicleId { get; set; } 
        public string Model { get; set; }
        public string Type { get; set; }
        public int RacerVehicleID { get; set; }
        public RacerVehicle RacerVehicle { get; set; }
        public Vehicle()
        {
            VehicleId = _nextId++;
        }

    }
}
