using System;

namespace calc_pressure_losses_along_len.Physics
{
    public class HydraulicFrictionCoefficient
    {
        public static readonly double MaxReynoldsNumberForLaminarFlow = 2000;

        public static readonly double MinReynoldsNumberForTransientFlow = 2000;
        public static readonly double MaxReynoldsNumberForTransientFlow = 4000;

        public static readonly double MinReynoldsNumberForTurbulenFlow = 4000;

        private readonly ReynoldsNumber reynoldsNumber;
        private readonly double equivalentRoughness;
        private readonly double pipelineInnerDiameter;

        private readonly double val;

        public HydraulicFrictionCoefficient(
            ReynoldsNumber reynoldsNumber,
            double equivalentRoughness,
            double pipelineInnerDiameter)
        {
            this.reynoldsNumber = reynoldsNumber;
            this.equivalentRoughness = equivalentRoughness;
            this.pipelineInnerDiameter = pipelineInnerDiameter;

            if (IsLaminarFlow())
                val = CalcLaminarFlowReynoldsNumber();
            else if (IsTransientFlow())
                val = CalcTransientFlow();
            else if (IsTurbulentFlow())
                val = CalcTurbulentFlowReynoldsNumber();
            else
                throw new ArgumentException();
        }

        private double CalcLaminarFlowReynoldsNumber()
        {
            return 64 / ReynoldsNumber;
        }

        private double CalcTurbulentFlowReynoldsNumber()
        {
            return
                0.11 *
                Math.Pow(
                    ((equivalentRoughness / pipelineInnerDiameter) + (68 / ReynoldsNumber)),
                    0.25);
        }

        private double CalcTransientFlow()
        {
            double arg = (Math.PI / 2) * (ReynoldsNumber / 2000 - 1);
            double sin = Math.Sin(arg);
            double ksi = Math.Pow(sin, 2);

            return (1 - ksi) * CalcLaminarFlowReynoldsNumber() + ksi * CalcTurbulentFlowReynoldsNumber();
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
