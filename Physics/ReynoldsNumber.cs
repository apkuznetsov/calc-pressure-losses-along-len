namespace calc_pressure_losses_along_len.Physics
{
    public class ReynoldsNumber
    {
        private readonly double averageFlowRate;
        private readonly double roundPipeHydraulicRadius;
        private readonly double kinematicViscosityCoefficient;

        private readonly double val;

        public ReynoldsNumber(double averageFlowRate, double pipelineInnerDiameter, double kinematicViscosityCoefficient)
        {
            this.averageFlowRate = averageFlowRate;
            roundPipeHydraulicRadius = pipelineInnerDiameter / 4;
            this.kinematicViscosityCoefficient = kinematicViscosityCoefficient;

            val = this.averageFlowRate * 4 * roundPipeHydraulicRadius / this.kinematicViscosityCoefficient;
        }

        public double AverageFlowRate
        {
            get
            {
                return averageFlowRate;
            }
        }

        public double RoundPipeHydraulicRadius
        {
            get
            {
                return roundPipeHydraulicRadius;
            }
        }

        private double KinematicViscosityCoefficient
        {
            get
            {
                return kinematicViscosityCoefficient;
            }
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
