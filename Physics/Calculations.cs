namespace calc_pressure_losses_along_len.Physics
{
    public static class Calculations
    {
        public static PressureLoss CreatePressureLoss(
            double pipelineFluidFlow,
            double pipelineInnerDiameter,
            double kinematicViscosityCoefficient,
            double equivalentRoughness,
            double pipelineLength,
            double fluidDensity)
        {
            AverageFlowRate averageFlowRate = new AverageFlowRate(pipelineFluidFlow, pipelineInnerDiameter);
            ReynoldsNumber reynoldsNumber = new ReynoldsNumber(averageFlowRate, pipelineInnerDiameter, kinematicViscosityCoefficient);
            HydraulicFrictionCoefficient hydraulicFrictionCoefficient = new HydraulicFrictionCoefficient(reynoldsNumber, equivalentRoughness, pipelineInnerDiameter);

            return new PressureLoss(hydraulicFrictionCoefficient, pipelineLength, pipelineInnerDiameter, averageFlowRate, fluidDensity);
        }

        public static double CalcPressureLoss(
            double pipelineFluidFlow,
            double pipelineInnerDiameter,
            double kinematicViscosityCoefficient,
            double equivalentRoughness,
            double pipelineLength,
            double fluidDensity)
        {
            return CreatePressureLoss(
                pipelineFluidFlow,
                pipelineInnerDiameter,
                kinematicViscosityCoefficient,
                equivalentRoughness,
                pipelineLength,
                fluidDensity).Value;
        }
    }
}

