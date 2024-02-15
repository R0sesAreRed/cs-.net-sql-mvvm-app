using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;
using WpfApp1.Stores;
using WpfApp1.ViewModel;

namespace WpfApp1.Comms
{
    class DodajQ : commBase
    {
        
        private readonly WybieratorFrajdyVM _WFVM;
        private readonly Interface _interface;
        public DodajQ(WybieratorFrajdyVM wybieratorFrajdyVm, Interface interfacoinfdsa)
        {
            _WFVM = wybieratorFrajdyVm;
            _interface = interfacoinfdsa;
        }

        public override void Execute(object parameter)
        {
            _interface.AddToListBoxQ(new LoadQ(_interface.AddNewQuiz(_WFVM.NameQ), _WFVM.NameQ));
            _WFVM.LQuizy = _interface.GetTableQ();
            
        }
    }
}
