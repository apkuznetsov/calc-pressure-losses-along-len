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
    }
}
