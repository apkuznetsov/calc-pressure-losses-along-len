namespace calc_pressure_losses_along_len.Dtos
{
    public class KinematicViscosityCoefficients
    {
        public int Id { get; set; }

        public string SubstanceName { get; set; }

        public double ValueAt0Celsius { get; set; }

        public double ValueAt20Celsius { get; set; }

        public double ValueAt50Celsius { get; set; }

        public double ValueAt70Celsius { get; set; }

        public double ValueAt100Celsius { get; set; }
    }
}
