namespace calc_pressure_losses_along_len.Physics
{
    public class ReynoldsNumber
    {
        private readonly double val;

        public ReynoldsNumber(double averageFlowRate, double pipelineInnerDiameter, double kinematicViscosityCoefficient)
        {
            double roundPipeHydraulicRadius = pipelineInnerDiameter / 4;

            val = averageFlowRate * 4 * roundPipeHydraulicRadius / kinematicViscosityCoefficient;
        }

        public double Value
        {
            get
            {
                return val;
            }
        }
    }
}
