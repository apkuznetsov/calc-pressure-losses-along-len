using calc_pressure_losses_along_len.Db;
using calc_pressure_losses_along_len.Dtos;
using calc_pressure_losses_along_len.View.Epr;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace calc_pressure_losses_along_len.ViewModel
{
    public class EprVm : INotifyPropertyChanged
    {
        private ApplicationContext db;

        private DelegateCommand addEprCommand;
        private DelegateCommand editEprCommand;
        private DelegateCommand deleteEprCommand;

        IEnumerable<EquivalentPipeRoughness> eprs;

        public EprVm()
        {
            db = new ApplicationContext();
            db.Eprs.Load();
            Eprs = db.Eprs.Local.ToBindingList();
        }

        public IEnumerable<EquivalentPipeRoughness> Eprs
        {
            get
            {
                return eprs;
            }
            set
            {
                eprs = value;
                OnPropertyChanged(nameof(Eprs));
            }
        }

        public DelegateCommand AddEprCommand
        {
            get
            {
                return addEprCommand ??
                  (addEprCommand = new DelegateCommand((o) =>
                  {
                      EprDialog eprDialog = new EprDialog(new EquivalentPipeRoughness());
                      if (eprDialog.ShowDialog() == true)
                      {
                          EquivalentPipeRoughness epr = eprDialog.EquivalentPipeRoughness;
                          db.Eprs.Add(epr);
                          db.SaveChanges();
                      }
                  }));
            }
        }

        public DelegateCommand EditEprCommand
        {
            get
            {
                return editEprCommand ??
                  (editEprCommand = new DelegateCommand((selectedItem) =>
                  {
                      if (selectedItem == null)
                          return;

                      EquivalentPipeRoughness epr = selectedItem as EquivalentPipeRoughness;

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
                  }));
            }
        }

        public DelegateCommand DeleteEprCommand
        {
            get
            {
                return deleteEprCommand ??
                  (deleteEprCommand = new DelegateCommand((selectedItem) =>
                  {
                      if (selectedItem == null)
                          return;

                      EquivalentPipeRoughness epr = selectedItem as EquivalentPipeRoughness;
                      db.Eprs.Remove(epr);
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
