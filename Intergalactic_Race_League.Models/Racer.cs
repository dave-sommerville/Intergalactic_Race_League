namespace Intergalactic_Race_League.Models
{
    public class Racer
    {
        public int RacerId { get; set; }
        public string DriverName { get; set; }
        public int DriverHeightInCm { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<RaceParticipant> RaceParticipants { get; set; } = new List<RaceParticipant>();// Many to many
        public List<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
        
    }
}
