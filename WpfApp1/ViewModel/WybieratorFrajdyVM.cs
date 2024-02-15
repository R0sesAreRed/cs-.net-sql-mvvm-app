using WpfApp1.Comms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.Stores;

namespace WpfApp1.ViewModel
{
    public class WybieratorFrajdyVM : MainVM
    {
        private ObservableCollection<LoadQ> _lQuizy = new ObservableCollection<LoadQ>();
        private string _nameq = "";
        private int _indeks = -1;

        public int Indeks
        {
            get
            {
                return _indeks;
            }
            set
            {
                _indeks = value;
                OnPropertyChanged(nameof(Indeks));
            }
        }

        public ObservableCollection<LoadQ> LQuizy
        {
            get
            {
                return _lQuizy;
            }
            set
            {
                _lQuizy = value;
                OnPropertyChanged(nameof(LQuizy));
            }
        }
        public string NameQ
        {
            get
            {
                return _nameq;
            }
            set
            {
                _nameq = value;
                OnPropertyChanged(nameof(NameQ));
            }
        }

        public ICommand NewQ { get; }
        public ICommand LoadQ { get; }
        public ICommand DelQ { get; }

        public WybieratorFrajdyVM(Interface interfacoinfdsa, NavStore navstore)
        {
            NewQ = new DodajQ(this, interfacoinfdsa);
            LoadQ = new WczytajQ(this, interfacoinfdsa, navstore);
            DelQ = new UsunQ(this, interfacoinfdsa);
            interfacoinfdsa.ReadQuizes(LQuizy);
            interfacoinfdsa.SetTableQ(LQuizy);
        }
    }
}
