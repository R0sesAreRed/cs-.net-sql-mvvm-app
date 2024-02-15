using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Stores;

namespace WpfApp1.ViewModel
{
    public class GlowneVM : MainVM
    {

        private readonly NavStore _navStore;
        public MainVM CurrentViewModel => _navStore.CurrentVM;

        public GlowneVM(NavStore navStore)
        {
            _navStore = navStore;
            _navStore.VMChanged += OnVMChanged;
        }

        private void OnVMChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
