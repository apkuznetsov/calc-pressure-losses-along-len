using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class PressureLossCalculation
    {
        private readonly AverageFlowRate averageFlowRate;
        private readonly ReynoldsNumber reynoldsNumber;
        private readonly HydraulicFrictionCoefficient hydraulicFrictionCoefficient;

        private readonly PressureLoss pressureLoss;

        public PressureLossCalculation(
            double pipelineFluidFlow,
            double pipelineInnerDiameter,
            double kinematicViscosityCoefficient,
            double equivalentRoughness,
            double pipelineLength,
            double fluidDensity)
        {
            if (pipelineFluidFlow < 0
                || pipelineInnerDiameter < 0
                || kinematicViscosityCoefficient < 0
                || equivalentRoughness < 0
                || pipelineLength < 0
                || fluidDensity < 0)
                throw new ArgumentOutOfRangeException();

            averageFlowRate = new AverageFlowRate(pipelineFluidFlow, pipelineInnerDiameter);
            reynoldsNumber = new ReynoldsNumber(averageFlowRate, pipelineInnerDiameter, kinematicViscosityCoefficient);
            hydraulicFrictionCoefficient = new HydraulicFrictionCoefficient(reynoldsNumber, equivalentRoughness, pipelineInnerDiameter);

            pressureLoss = new PressureLoss(hydraulicFrictionCoefficient, pipelineLength, pipelineInnerDiameter, averageFlowRate, fluidDensity);
        }

        public override string ToString()
        {
            return
                averageFlowRate + "\n\n" +
                reynoldsNumber + "\n\n" +
                hydraulicFrictionCoefficient + "\n\n" +
                pressureLoss + "\n";
        }
    }
}
