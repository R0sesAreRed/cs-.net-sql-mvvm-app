using WpfApp1.Comms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class GeneratorFrajdyVM : MainVM
    {
        private string _pytanie = ""; //Following 5 values are assigned as default to empty to prevent null pointers in AddQComm.cs do not delete!
        private string _odp1 = "";
        private string _odp2 = "";
        private string _odp3 = "";
        private string _odp4 = "";
        private bool _o1;
        private bool _o2;
        private bool _o3;
        private bool _o4;
        private ObservableCollection<Dane> _quizy = new ObservableCollection<Dane>();
        private int _indeks = -1;
        private bool _editing = false;


        public bool Editing
        {
            get{ return _editing; }
            set { _editing = value; }
        }


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


        public ObservableCollection<Dane> Quizy
        {
            get
            {
                return _quizy;
            }
            set
            {
                _quizy = value;
                OnPropertyChanged(nameof(Quizy));
            }
        }

        public string Pytanie
        {
            get
            {
                return _pytanie;
            }
            set
            {
                _pytanie = value;
                OnPropertyChanged(nameof(Pytanie));
            }
        }

        public string Odp1
        {
            get
            {
                return _odp1;
            }
            set
            {
                _odp1 = value;
                OnPropertyChanged(nameof(Odp1));
            }
        }
        public string Odp2
        {
            get
            {
                return _odp2;
            }
            set
            {
                _odp2 = value;
                OnPropertyChanged(nameof(Odp2));
            }
        }
        public string Odp3
        {
            get
            {
                return _odp3;
            }
            set
            {
                _odp3 = value;
                OnPropertyChanged(nameof(Odp3));
            }
        }
        public string Odp4
        {
            get
            {
                return _odp4;
            }
            set
            {
                _odp4 = value;
                OnPropertyChanged(nameof(Odp4));
            }
        }
        public bool O1
        {
            get
            {
                return _o1;
            }
            set
            {
                _o1 = value;
                OnPropertyChanged(nameof(O1));
            }
        }
        public bool O2
        {
            get
            {
                return _o2;
            }
            set
            {
                _o2 = value;
                OnPropertyChanged(nameof(O2));
            }
        }
        public bool O3
        {
            get
            {
                return _o3;
            }
            set
            {
                _o3 = value;
                OnPropertyChanged(nameof(O3));
            }
        }
        public bool O4
        {
            get
            {
                return _o4;
            }
            set
            {
                _o4 = value;
                OnPropertyChanged(nameof(O4));
            }
        }
        public ICommand Dodaj { get; }
        public ICommand Wczytaj { get; }

        public ICommand Usun { get; }

        public GeneratorFrajdyVM(Interface interfacoinfdsa)
        {
            Dodaj = new AddQComm(this, interfacoinfdsa);
            Wczytaj = new EditQComm(this, interfacoinfdsa);
            Usun = new DeleteQComm(this, interfacoinfdsa);
            interfacoinfdsa.ReadQuizContent(Quizy, interfacoinfdsa.QuizId);
            interfacoinfdsa.SetTable(Quizy);
        }
    }
}
