using calc_pressure_losses_along_len.Dtos;
using System.Windows;

namespace calc_pressure_losses_along_len.View
{
    public partial class KvcDialog : Window
    {
        public KinematicViscosityCoefficient KinematicViscosityCoefficient { get; set; }

        public KvcDialog(KinematicViscosityCoefficient kvc)
        {
            InitializeComponent();

            KinematicViscosityCoefficient = kvc;
            DataContext = KinematicViscosityCoefficient;
        }

        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
