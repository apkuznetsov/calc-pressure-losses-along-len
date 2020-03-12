using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class PressureLoss
    {
        private readonly double val;

        public PressureLoss(
            HydraulicFrictionCoefficient hydraulicFrictionCoefficient,
            double pipelineLength,
            double pipelineInnerDiameter,
            AverageFlowRate averageFlowRate,
            double fluidDensity)
        {
            if (hydraulicFrictionCoefficient == null
                || averageFlowRate == null)
                throw new ArgumentNullException();
            if (pipelineLength < 0
                || pipelineInnerDiameter < 0
                || fluidDensity < 0)
                throw new ArgumentOutOfRangeException();

            val =
                hydraulicFrictionCoefficient.Value *
                (pipelineLength / pipelineInnerDiameter) *
                (Math.Pow(averageFlowRate.Value, 2) / 2) *
                fluidDensity;
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
            return "потери давления = " + Value + " Па";
        }
    }
}
