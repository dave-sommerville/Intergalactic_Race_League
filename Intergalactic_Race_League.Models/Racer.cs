namespace Intergalactic_Race_League.Models
{
    public class Racer
    {
        private static int _nextId;
        public int RacerId { get; set; }
        public string DriverName { get; set; }
        public int DriverAge { get; set; }
        public int DriverHeightInCm { get; set; }
        public string DriverCountry { get; set; }

        public Racer()
        {
            RacerId = _nextId++;
        }
    }
}
