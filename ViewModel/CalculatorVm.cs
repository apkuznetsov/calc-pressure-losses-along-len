using calc_pressure_losses_along_len.Physics;
using calc_pressure_losses_along_len.View.Epr;
using calc_pressure_losses_along_len.View.Kvc;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace calc_pressure_losses_along_len.ViewModel
{
    public class CalculatorVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double pipelineFluidFlow;
        private double pipelineInnerDiameter;
        private double kinematicViscosityCoefficient;
        private double equivalentRoughness;
        private double pipelineLength;
        private double fluidDensity;

        public CalculatorVm()
        {
            CalcCommand = new DelegateCommand(CalcPressureLoss);
            OpenEprWindowCommand = new DelegateCommand(OpenEprWindow);
            OpenKvcWindowCommand = new DelegateCommand(OpenKvcWindow);
        }

        public ICommand CalcCommand
        {
            get; private set;
        }

        public ICommand OpenEprWindowCommand
        {
            get; private set;
        }

        public ICommand OpenKvcWindowCommand
        {
            get; private set;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void CalcPressureLoss(object obj)
        {
            try
            {
                PressureLossCalculation pressureLossCalculation = new PressureLossCalculation(
                    PipelineFluidFlow,
                    PipelineInnerDiameter,
                    KinematicViscosityCoefficient,
                    EquivalentRoughness,
                    PipelineLength,
                    FluidDensity);

                MessageBox.Show(pressureLossCalculation.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Значения параметров должны быть больше нуля");
            }
        }

        private void OpenEprWindow(object obj)
        {
            new EprWindow().Show();
        }

        private void OpenKvcWindow(object obj)
        {
            new KvcWindow().Show();
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
    }
}
