using calc_pressure_losses_along_len.Dtos;
using System.Windows;

namespace calc_pressure_losses_along_len.View
{
    public partial class EquivalentPipeRoughnessWindow : Window
    {
        private EquivalentPipeRoughness EquivalentPipeRoughness { get; set; }

        public EquivalentPipeRoughnessWindow(EquivalentPipeRoughness epr)
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
