using calc_pressure_losses_along_len.ViewModel;
using System.Windows;

namespace calc_pressure_losses_along_len.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CalculatorVm();
        }
    }
}
