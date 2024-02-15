using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.ViewModel;

namespace WpfApp1.Stores
{
    public class NavStore
    {
        private MainVM _currentVM;

        public MainVM CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                OnVMChanged();
            }
        }

        public event Action VMChanged;

        private void OnVMChanged()
        {
            VMChanged?.Invoke();
        }


         


    }
}
