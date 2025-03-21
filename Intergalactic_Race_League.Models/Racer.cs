﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intergalactic_Race_League.Models
{
    public class Racer
    {
        [Key] 
        public int RacerId { get; set; }
        public string DriverName { get; set; }
        public int DriverAge { get; set; }
        public int DriverHeightInCm { get; set; }
        public string DriverCountry { get; set; }
        public RacerVehicle RacerVehicle { get; set; }

    }
}
