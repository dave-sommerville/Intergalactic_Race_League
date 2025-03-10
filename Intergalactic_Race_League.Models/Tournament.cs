using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intergalactic_Race_League.Models
{
    public class Tournament
    {
        private static int _nextId;
        [Key]
        public int TournamentId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
        // public int StartingNumOfRaces { get; set; }  - Or add to view/controller as array size
        public Race[] AllRaces { get; set; }
        public List<RacerVehicle> RacerVehicles { get; set; }
        public Race[] RankedRaces { get; set; }
        public Tournament()
        {
            //TournamentId = _nextId++;
        }
    }
}
