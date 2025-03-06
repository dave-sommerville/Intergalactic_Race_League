using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergalactic_Race_League.Models
{
    public class RaceParticipant
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int RacerId { get; set; }
        public Racer Racer { get; set; }
    }

}
