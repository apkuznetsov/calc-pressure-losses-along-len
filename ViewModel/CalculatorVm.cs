using System.ComponentModel;

namespace calc_pressure_losses_along_len.ViewModel
{
    public class CalculatorVm : INotifyPropertyChanged
    {
        private double pipelineFluidFlow;
        private double pipelineInnerDiameter;
        private double kinematicViscosityCoefficient;
        private double equivalentRoughness;
        private double pipelineLength;
        private double fluidDensity;

        public double PipelineFluidFlow
        {
            get
            {
                return pipelineFluidFlow;
            }

            set
            {
                pipelineFluidFlow = value;
                OnPropertyChanged(nameof(PipelineFluidFlow));
            }
        }

        public double PipelineInnerDiameter
        {
            get
            {
                return pipelineInnerDiameter;
            }

            set
            {
                pipelineInnerDiameter = value;
                OnPropertyChanged(nameof(PipelineInnerDiameter));
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
                OnPropertyChanged(nameof(KinematicViscosityCoefficient));
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
                OnPropertyChanged(nameof(EquivalentRoughness));
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
                OnPropertyChanged(nameof(PipelineLength));
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
                OnPropertyChanged(nameof(FluidDensity));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
