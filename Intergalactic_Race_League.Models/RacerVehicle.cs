using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intergalactic_Race_League.Models
{
    public class RacerVehicle
    {
        [Key]
        public int RacerVehicleId { get; set; }
        [ForeignKey("Racer")]
        public int RacerId { get; set; }
        public Racer Racer { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
