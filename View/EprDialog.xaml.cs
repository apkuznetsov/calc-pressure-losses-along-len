using calc_pressure_losses_along_len.Dtos;
using System.Windows;

namespace calc_pressure_losses_along_len.View
{
    public partial class EprDialog : Window
    {
        public EquivalentPipeRoughness EquivalentPipeRoughness { get; set; }

        public EprDialog(EquivalentPipeRoughness epr)
        {
            InitializeComponent();

            EquivalentPipeRoughness = epr;
            DataContext = EquivalentPipeRoughness;
        }

        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
