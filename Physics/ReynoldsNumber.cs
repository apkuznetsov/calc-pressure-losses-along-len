using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class ReynoldsNumber
    {
        private readonly double val;

        public ReynoldsNumber(
            AverageFlowRate averageFlowRate, 
            double pipelineInnerDiameter, 
            double kinematicViscosityCoefficient)
        {
            if (averageFlowRate == null)
                throw new ArgumentNullException();
            if (pipelineInnerDiameter < 0
                || kinematicViscosityCoefficient < 0)
                throw new ArgumentOutOfRangeException();

            double roundPipeHydraulicRadius = pipelineInnerDiameter / 4;

            val = averageFlowRate.Value * 4 * roundPipeHydraulicRadius / kinematicViscosityCoefficient;
        }

        public double Value
        {
            get
            {
                return val;
            }
        }

        public override string ToString()
        {
            return "число Рейнольдса = " + Value;
        }
    }
}
