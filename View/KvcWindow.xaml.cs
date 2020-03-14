using calc_pressure_losses_along_len.Db;
using calc_pressure_losses_along_len.Dtos;
using System.Data.Entity;
using System.Windows;

namespace calc_pressure_losses_along_len.View
{
    public partial class KvcWindow : Window
    {
        private readonly ApplicationContext db;

        public KvcWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Kvcs.Load();
            DataContext = db.Kvcs.Local.ToBindingList();
        }

        private void AddKvc_Click(object sender, RoutedEventArgs e)
        {
            KvcDialog kvcDialog = new KvcDialog(new KinematicViscosityCoefficient());

            if (kvcDialog.ShowDialog() == true)
            {
                KinematicViscosityCoefficient kvc = kvcDialog.KinematicViscosityCoefficient;
                db.Kvcs.Add(kvc);
                db.SaveChanges();
            }
        }

        private void EditKvc_Click(object sender, RoutedEventArgs e)
        {
            if (kvcsList.SelectedItem == null)
                return;

            KinematicViscosityCoefficient kvc = kvcsList.SelectedItem as KinematicViscosityCoefficient;

            KvcDialog kvcDialog = new KvcDialog(new KinematicViscosityCoefficient
            {
                Id = kvc.Id,
                SubstanceName = kvc.SubstanceName,
                ValueAt0Celsius = kvc.ValueAt0Celsius,
                ValueAt20Celsius = kvc.ValueAt20Celsius,
                ValueAt50Celsius = kvc.ValueAt50Celsius,
                ValueAt70Celsius = kvc.ValueAt70Celsius,
                ValueAt100Celsius = kvc.ValueAt100Celsius
            });

            if (kvcDialog.ShowDialog() == true)
            {
                kvc = db.Kvcs.Find(kvcDialog.KinematicViscosityCoefficient.Id);
                if (kvc != null)
                {
                    kvc.SubstanceName = kvcDialog.KinematicViscosityCoefficient.SubstanceName;
                    kvc.ValueAt0Celsius = kvcDialog.KinematicViscosityCoefficient.ValueAt0Celsius;
                    kvc.ValueAt20Celsius = kvcDialog.KinematicViscosityCoefficient.ValueAt20Celsius;
                    kvc.ValueAt50Celsius = kvcDialog.KinematicViscosityCoefficient.ValueAt50Celsius;
                    kvc.ValueAt70Celsius = kvcDialog.KinematicViscosityCoefficient.ValueAt70Celsius;
                    kvc.ValueAt100Celsius = kvcDialog.KinematicViscosityCoefficient.ValueAt100Celsius;

                    db.Entry(kvc).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void DeleteKvc_Click(object sender, RoutedEventArgs e)
        {
            if (kvcsList.SelectedItem == null)
                return;

            KinematicViscosityCoefficient kvc = kvcsList.SelectedItem as KinematicViscosityCoefficient;
            db.Kvcs.Remove(kvc);
            db.SaveChanges();
        }
    }
}
