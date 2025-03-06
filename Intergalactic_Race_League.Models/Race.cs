using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergalactic_Race_League.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public List<RaceParticipant> RaceParticipants { get; set; } = new List<RaceParticipant>(); //Many to many
        public List<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
    }
}
