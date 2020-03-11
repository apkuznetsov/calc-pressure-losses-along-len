using System.Windows;

namespace calc_pressure_losses_along_len
{
    public partial class MainWindow : Window
    {
        private readonly PressureLossCalcVm viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new PressureLossCalcVm();
            DataContext = viewModel;
        }
    }
}
