using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

namespace ZadaniaWPF.ModelWidoku
{
    public class Zadanie : INotifyPropertyChanged
    {

        private Model.Zadanie model;

        #region Własności
        public string Opis
        {
            get
            {
                return model.Opis;
            }
        }

        public Model.PriorytetZadania Priorytet
        {
            get
            {
                return model.Priorytet;
            }
        }

        public DateTime DataUtworzenia
        {
            get
            {
                return model.DataUtworzenia;
            }
        }

        public DateTime PlanowanyTerminRealizacji
        {
            get
            {
                return model.PlanowanyTerminRealizacji;
            }
        }

        public bool CzyZrealizowane
        {
            get
            {
                return model.CzyZrealizowane;
            }
        }

        public bool CzyZadaniePozostajeNiezrealizowanePoPlanowanymTerminie
        {
            get
            {
                return !CzyZrealizowane && (DateTime.Now > PlanowanyTerminRealizacji);
            }
        }
        #endregion

        public Zadanie(Model.Zadanie zadanie)
        {
            this.model = zadanie;
        }

        public Zadanie(string opis, DateTime dataUtworzenia, DateTime planowanyTerminRealizacji, Model.PriorytetZadania priorytetZadania, bool czyZrealizowane)
        {
            model = new Model.Zadanie(opis, dataUtworzenia, planowanyTerminRealizacji, priorytetZadania, czyZrealizowane);
        }

        public Model.Zadanie GetModel()
        {
            return model;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(params string[] nazwyWłasności)
        {
            if(PropertyChanged != null)
            {
                foreach (string nazwaWłasności in nazwyWłasności)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
            }
        }
        #endregion

        #region Polecenia
        ICommand oznaczJakoZrealizowane;

        public ICommand OznaczJakoZrealizowane
        {
            get
            {
                if (oznaczJakoZrealizowane == null)
                    oznaczJakoZrealizowane = new RelayCommand(
                        oznaczJakoZrealizowane =>
                        {
                            model.CzyZrealizowane = true;
                            OnPropertyChanged("CzyZrealizowane",
                                "CzyZadaniePozostajeNiezrealizowanePoPlanowanymTerminie");
                        },
                        oznaczJakoZrealizowane =>
                        {
                            return !model.CzyZrealizowane;
                        });
                return oznaczJakoZrealizowane;
            }
        }

        ICommand oznaczJakoNiezrealizowane = null;
        public ICommand OznaczJakoNiezrealizowane
        {
            get
            {
                if (oznaczJakoNiezrealizowane == null)
                    oznaczJakoNiezrealizowane = new RelayCommand(
                    o =>
                    {
                        model.CzyZrealizowane = false;
                        OnPropertyChanged("CzyZrealizowane",
                        "CzyZadaniePozostajeNiezrealizowanePoPlanowanymTerminie");
                    },
                    o =>
                    {
                        return model.CzyZrealizowane;
                    });
                return oznaczJakoNiezrealizowane;
            }
        }
            #endregion
    }
}
