using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class AverageFlowRate
    {
        private readonly double pipelineFluidFlow;
        private readonly double flowSectionArea;

        private readonly double val;

        public AverageFlowRate(double pipelineFluidFlow, double pipelineInnerDiameter)
        {
            this.pipelineFluidFlow = pipelineFluidFlow;
            flowSectionArea =
                Math.PI * Math.Pow(pipelineInnerDiameter, 2) / 2;

            val = pipelineFluidFlow / flowSectionArea;
        }

        public double PipelineFluidFlow
        {
            get
            {
                return pipelineFluidFlow;
            }
        }

        public double FlowSectionArea
        {
            get
            {
                return flowSectionArea;
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
