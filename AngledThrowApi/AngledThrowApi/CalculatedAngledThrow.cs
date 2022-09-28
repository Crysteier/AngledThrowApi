namespace SikmyVrhApi
{
    public class CalculatedAngledThrow
    {
        public List<Coordinatas> Coords { get; set; }
        public double DistanceTraveled { get; set; }
        public double FinishTime { get; set; }
        public double StepCount { get; set; }
        public double tds { get; set; }
        public double HighestPoint { get; set; }

        public CalculatedAngledThrow()
        {
            Coords = new List<Coordinatas>();
            DistanceTraveled = 0;
            FinishTime = 0;
            StepCount = 0;
            tds = 0;
            HighestPoint = 0;
        }
    }
}
