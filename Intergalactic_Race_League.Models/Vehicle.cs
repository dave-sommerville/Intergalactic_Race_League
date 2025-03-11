using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intergalactic_Race_League.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; } 
        public string Model { get; set; }
        public string Type { get; set; }
        public RacerVehicle RacerVehicle { get; set; }
    }
}
