namespace Intergalactic_Race_League.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int TournamentId { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public Tournament Tournament { get; set; }
        public Racer RacerOne { get; set; }
        public Racer RacerTwo { get; set; }
        public Racer Winner { get; set; }
    }
}
