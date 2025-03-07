namespace Intergalactic_Race_League.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public int StartingNumOfRaces { get; set; } // This might not need to be included in the attributes themselves 
        public Race[] AllRaces { get; set; }
        public List<RacerVehicle> RacerVehicles { get; set; }
        public Race[] RankedRaces {get; set;}
    }
}
