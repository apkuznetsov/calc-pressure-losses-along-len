using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class PressureLossObj
    {
        private readonly double hydraulicPressureCoefficient;
        private readonly double pipelineLength;
        private readonly double pipelineInnerDiameter;
        private readonly double averageFlowRate;
        private readonly double fluidDensity;

        private readonly double pressureLoss;

        public PressureLossObj(
            double hydraulicPressureCoefficient,
            double pipelineLength,
            double pipelineInnerDiameter,
            double averageFlowRate,
            double fluidDensity)
        {
            this.hydraulicPressureCoefficient = hydraulicPressureCoefficient;
            this.pipelineLength = pipelineLength;
            this.pipelineInnerDiameter = pipelineInnerDiameter;
            this.averageFlowRate = averageFlowRate;
            this.fluidDensity = fluidDensity;

            pressureLoss =
                hydraulicPressureCoefficient *
                (pipelineLength / pipelineInnerDiameter) *
                (Math.Pow(averageFlowRate, 2) / 2) *
                fluidDensity;
        }

        public double HydraulicPressureCoefficient
        {
            get
            {
                return hydraulicPressureCoefficient;
            }
        }

        public double PipelineLength
        {
            get
            {
                return pipelineLength;
            }
        }

        public double PipelineInnerDiameter
        {
            get
            {
                return pipelineInnerDiameter;
            }
        }

        public double AverageFlowRate
        {
            get
            {
                return averageFlowRate;
            }
        }

        public double FluidDensity
        {
            get
            {
                return fluidDensity;
            }
        }

        public double PressureLoss
        {
            get
            {
                return pressureLoss;
            }
        }
    }
}
