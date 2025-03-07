namespace Intergalactic_Race_League.Models
{
    public class RacerVehicle
    {
        private static int _nextId;
        public int RacerVehicleId { get; set; }
        public int RacerId { get; set; }
        public Racer Racer { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public RacerVehicle()
        {
            RacerVehicleId = _nextId++;
        }
    }
}
