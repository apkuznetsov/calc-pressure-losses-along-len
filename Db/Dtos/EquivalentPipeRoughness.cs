using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace calc_pressure_losses_along_len.Dtos
{
    public class EquivalentPipeRoughness : INotifyPropertyChanged
    {
        private string pipeName;
        private double roughnessValue;

        public int Id { get; set; }

        public string PipeName
        {
            get
            {
                return pipeName;
            }
            set
            {
                pipeName = value;
                OnPropertyChanged(nameof(PipeName));
            }
        }

        public double RoughnessValue
        {
            get
            {
                return roughnessValue;
            }
            set
            {
                roughnessValue = value;
                OnPropertyChanged(nameof(RoughnessValue));
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
