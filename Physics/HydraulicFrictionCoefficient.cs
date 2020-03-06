using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class HydraulicFrictionCoefficient
    {
        #region константы
        public static readonly double MaxReynoldsNumberForLaminarFlow = 2000;

        public static readonly double MinReynoldsNumberForTransientFlow = 2000;
        public static readonly double MaxReynoldsNumberForTransientFlow = 4000;

        public static readonly double MinReynoldsNumberForTurbulenFlow = 4000;
        #endregion /константы

        private readonly ReynoldsNumber reynoldsNumber;
        private readonly double val;

        public HydraulicFrictionCoefficient(
            ReynoldsNumber reynoldsNumber,
            double equivalentRoughness,
            double pipelineInnerDiameter)
        {
            this.reynoldsNumber = reynoldsNumber;

            if (IsLaminarFlow())
                val = CalcLaminarFlowReynoldsNumber();
            else if (IsTransientFlow())
                val = CalcTransientFlow(equivalentRoughness, pipelineInnerDiameter);
            else if (IsTurbulentFlow())
                val = CalcTurbulentFlowReynoldsNumber(equivalentRoughness, pipelineInnerDiameter);
            else
                throw new ArgumentException();
        }

        private double CalcLaminarFlowReynoldsNumber()
        {
            return 64 / ReynoldsNumber;
        }

        private double CalcTurbulentFlowReynoldsNumber(double equivalentRoughness, double pipelineInnerDiameter)
        {
            return
                0.11 *
                Math.Pow(
                    ((equivalentRoughness / pipelineInnerDiameter) + (68 / ReynoldsNumber)),
                    0.25);
        }

        private double CalcTransientFlow(double equivalentRoughness, double pipelineInnerDiameter)
        {
            double arg = (Math.PI / 2) * (ReynoldsNumber / 2000 - 1);
            double sin = Math.Sin(arg);
            double ksi = Math.Pow(sin, 2);

            return (1 - ksi) * CalcLaminarFlowReynoldsNumber() + ksi * CalcTurbulentFlowReynoldsNumber(equivalentRoughness, pipelineInnerDiameter);
        }

        private double ReynoldsNumber
        {
            get
            {
                return reynoldsNumber.Value;
            }
        }

        public double Value
        {
            get
            {
                return val;
            }
        }

        public bool IsLaminarFlow()
        {
            return ReynoldsNumber <= MaxReynoldsNumberForLaminarFlow;
        }

        public bool IsTransientFlow()
        {
            return (ReynoldsNumber >= MinReynoldsNumberForTransientFlow) && (ReynoldsNumber <= MaxReynoldsNumberForTransientFlow);
        }

        public bool IsTurbulentFlow()
        {
            return ReynoldsNumber >= MinReynoldsNumberForTurbulenFlow;
        }
    }
}
