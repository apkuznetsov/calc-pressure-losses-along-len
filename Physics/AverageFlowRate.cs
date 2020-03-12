using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class AverageFlowRate
    {
        private readonly double val;

        public AverageFlowRate(double pipelineFluidFlow, double pipelineInnerDiameter)
        {
            double flowSectionArea = Math.PI * Math.Pow(pipelineInnerDiameter, 2) / 2;

            val = pipelineFluidFlow / flowSectionArea;
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
            return "средняя скорость потока = " + Value + " куб.м/с";
        }
    }
}
