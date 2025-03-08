using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intergalactic_Race_League.Models
{
    public class Race
    {
        private static int _nextId;
        [Key]
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        [ForeignKey("RacerOne")] // I think
        public int RacerOneID { get; set; }
        public RacerVehicle RacerOne { get; set; }
        [ForeignKey("RacerTwo")] // I think 
        public int RacerTwoId { get; set; }
        public Racer RacerVehicle { get; set; }
        public Racer Winner { get; set; }

        public Race()
        {
            RaceId = _nextId++;
        }
    }
}
