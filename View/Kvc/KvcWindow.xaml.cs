using calc_pressure_losses_along_len.ViewModel;
using System.Windows;

namespace calc_pressure_losses_along_len.View.Kvc
{
    public partial class KvcWindow : Window
    {
        public KvcWindow()
        {
            InitializeComponent();

            DataContext = new KvcVm();
        }
    }
}
