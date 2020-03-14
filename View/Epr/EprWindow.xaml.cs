using calc_pressure_losses_along_len.Db;
using calc_pressure_losses_along_len.Dtos;
using System.Data.Entity;
using System.Windows;

namespace calc_pressure_losses_along_len.View.Epr
{
    public partial class EprWindow : Window
    {
        private readonly ApplicationContext db;

        public EprWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Eprs.Load();
            this.DataContext = db.Eprs.Local.ToBindingList();
        }

        private void AddEpr_Click(object sender, RoutedEventArgs e)
        {
            EprDialog eprDialog = new EprDialog(new EquivalentPipeRoughness());

            if (eprDialog.ShowDialog() == true)
            {
                EquivalentPipeRoughness epr = eprDialog.EquivalentPipeRoughness;
                db.Eprs.Add(epr);
                db.SaveChanges();
            }
        }

        private void EditEpr_Click(object sender, RoutedEventArgs e)
        {
            if (eprsList.SelectedItem == null)
                return;

            EquivalentPipeRoughness epr = eprsList.SelectedItem as EquivalentPipeRoughness;

            EprDialog eprDialog = new EprDialog(new EquivalentPipeRoughness
            {
                Id = epr.Id,
                PipeName = epr.PipeName,
                RoughnessValue = epr.RoughnessValue
            });

            if (eprDialog.ShowDialog() == true)
            {
                epr = db.Eprs.Find(eprDialog.EquivalentPipeRoughness.Id);
                if (epr != null)
                {
                    epr.PipeName = eprDialog.EquivalentPipeRoughness.PipeName;
                    epr.RoughnessValue = eprDialog.EquivalentPipeRoughness.RoughnessValue;

                    db.Entry(epr).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void DeleteEpr_Click(object sender, RoutedEventArgs e)
        {
            if (eprsList.SelectedItem == null)
                return;

            EquivalentPipeRoughness epr = eprsList.SelectedItem as EquivalentPipeRoughness;
            db.Eprs.Remove(epr);
            db.SaveChanges();
        }
    }
}
