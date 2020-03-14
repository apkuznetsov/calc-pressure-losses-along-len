using calc_pressure_losses_along_len.ViewModel;
using System.Windows;

namespace calc_pressure_losses_along_len.View.Epr
{
    public partial class EprWindow : Window
    {
        public EprWindow()
        {
            InitializeComponent();

            DataContext = new EprVm();
        }
    }
}
