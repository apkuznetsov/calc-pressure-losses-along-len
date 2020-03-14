using calc_pressure_losses_along_len.Db;
using calc_pressure_losses_along_len.Dtos;
using calc_pressure_losses_along_len.View.Kvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace calc_pressure_losses_along_len.ViewModel
{
    public class KvcVm
    {
        private readonly ApplicationContext db;

        private DelegateCommand addKvcCommand;
        private DelegateCommand editKvcCommand;
        private DelegateCommand deleteKvcCommand;

        IEnumerable<KinematicViscosityCoefficient> kvcs;

        public KvcVm()
        {
            db = new ApplicationContext();
            db.Kvcs.Load();
            Kvcs = db.Kvcs.Local.ToBindingList();
        }

        public IEnumerable<KinematicViscosityCoefficient> Kvcs
        {
            get
            {
                return kvcs;
            }
            set
            {
                kvcs = value;
                OnPropertyChanged(nameof(Kvcs));
            }
        }

        public DelegateCommand AddKvcCommand
        {
            get
            {
                return addKvcCommand ??
                  (addKvcCommand = new DelegateCommand((o) =>
                  {
                      KvcDialog kvcDialog = new KvcDialog(new KinematicViscosityCoefficient());

                      if (kvcDialog.ShowDialog() == true)
                      {
                          KinematicViscosityCoefficient kvc = kvcDialog.KinematicViscosityCoefficient;
                          db.Kvcs.Add(kvc);
                          db.SaveChanges();
                      }
                  }));
            }
        }

        public DelegateCommand EditKvcCommand
        {
            get
            {
                return editKvcCommand ??
                  (editKvcCommand = new DelegateCommand((selectedItem) =>
                  {
                      if (selectedItem == null)
                          return;

                      KinematicViscosityCoefficient kvc = selectedItem as KinematicViscosityCoefficient;

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
                  }));
            }
        }

        public DelegateCommand DeleteKvcCommand
        {
            get
            {
                return deleteKvcCommand ??
                  (deleteKvcCommand = new DelegateCommand((selectedItem) =>
                  {
                      if (selectedItem == null)
                          return;

                      KinematicViscosityCoefficient kvc = selectedItem as KinematicViscosityCoefficient;
                      db.Kvcs.Remove(kvc);
                      db.SaveChanges();
                  }));
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
