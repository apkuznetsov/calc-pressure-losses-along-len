using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace calc_pressure_losses_along_len.Dtos
{
    public class KinematicViscosityCoefficients : INotifyPropertyChanged
    {
        private string substanceName;
        private double valueAt0Celsius;
        private double valueAt20Celsius;
        private double valueAt50Celsius;
        private double valueAt70Celsius;
        private double valueAt100Celsius;

        public int Id { get; set; }

        public string SubstanceName
        {
            get
            {
                return substanceName;
            }
            set
            {
                substanceName = value;
                OnPropertyChanged(nameof(SubstanceName));
            }
        }

        public double ValueAt0Celsius
        {
            get
            {
                return valueAt0Celsius;
            }
            set
            {
                valueAt0Celsius = value;
                OnPropertyChanged(nameof(ValueAt0Celsius));
            }
        }

        public double ValueAt20Celsius
        {
            get
            {
                return valueAt20Celsius;
            }
            set
            {
                valueAt20Celsius = value;
                OnPropertyChanged(nameof(ValueAt20Celsius));
            }
        }

        public double ValueAt50Celsius
        {
            get
            {
                return valueAt50Celsius;
            }
            set
            {
                valueAt50Celsius = value;
                OnPropertyChanged(nameof(ValueAt50Celsius));
            }
        }

        public double ValueAt70Celsius
        {
            get
            {
                return valueAt70Celsius;
            }
            set
            {
                valueAt70Celsius = value;
                OnPropertyChanged(nameof(ValueAt70Celsius));
            }
        }

        public double ValueAt100Celsius
        {
            get
            {
                return valueAt100Celsius;
            }
            set
            {
                valueAt100Celsius = value;
                OnPropertyChanged(nameof(ValueAt100Celsius));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
