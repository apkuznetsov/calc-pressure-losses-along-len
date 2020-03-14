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
            double equivalentPipeRoughness,
            double pipelineLength,
            double fluidDensity)
        {
            if (pipelineFluidFlow < 0
                || pipelineInnerDiameter < 0
                || kinematicViscosityCoefficient < 0
                || equivalentPipeRoughness < 0
                || pipelineLength < 0
                || fluidDensity < 0)
                throw new ArgumentOutOfRangeException();

            averageFlowRate = new AverageFlowRate(pipelineFluidFlow, pipelineInnerDiameter);
            reynoldsNumber = new ReynoldsNumber(averageFlowRate, pipelineInnerDiameter, kinematicViscosityCoefficient);
            hydraulicFrictionCoefficient = new HydraulicFrictionCoefficient(reynoldsNumber, equivalentPipeRoughness, pipelineInnerDiameter);

            pressureLoss = new PressureLoss(hydraulicFrictionCoefficient, pipelineLength, pipelineInnerDiameter, averageFlowRate, fluidDensity);
        }

        public static string GetCalculationInfo(
            double pipelineFluidFlow,
            double pipelineInnerDiameter,
            double kinematicViscosityCoefficient,
            double equivalentRoughness,
            double pipelineLength,
            double fluidDensity)
        {
            return new PressureLossCalculation(
                pipelineFluidFlow,
                pipelineInnerDiameter,
                kinematicViscosityCoefficient,
                equivalentRoughness,
                pipelineLength,
                fluidDensity).ToString();
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
