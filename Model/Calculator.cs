namespace calc_pressure_losses_along_len.Model
{
    public class Calculator
    {
        private double pipelineInnerDiameter;
        private double pipelineLength;
        private double pipelineFluidFlow;
        private double kinematicViscosityCoefficient;
        private double equivalentRoughness;
        private double fluidDensity;

        public double PipelineInnerDiameter
        {
            get
            {
                return pipelineInnerDiameter;
            }

            set
            {
                pipelineInnerDiameter = value;
            }
        }

        public double PipelineLength
        {
            get
            {
                return pipelineLength;
            }

            set
            {
                pipelineLength = value;
            }
        }

        public double PipelineFluidFlow
        {
            get
            {
                return pipelineFluidFlow;
            }

            set
            {
                pipelineFluidFlow = value;
            }
        }

        public double KinematicViscosityCoefficient
        {
            get
            {
                return kinematicViscosityCoefficient;
            }

            set
            {
                kinematicViscosityCoefficient = value;
            }
        }

        public double EquivalentRoughness
        {
            get
            {
                return equivalentRoughness;
            }

            set
            {
                equivalentRoughness = value;
            }
        }

        public double FluidDensity
        {
            get
            {
                return fluidDensity;
            }

            set
            {
                fluidDensity = value;
            }
        }
    }
}
