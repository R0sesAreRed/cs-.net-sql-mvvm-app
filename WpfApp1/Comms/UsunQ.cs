using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Comms
{
    class UsunQ : commBase
    {

        private readonly WybieratorFrajdyVM _WFVM;
        private readonly Interface _interface;
        public UsunQ(WybieratorFrajdyVM wybieratorFrajdyVm, Interface interfacoinfdsa)
        {
            _WFVM = wybieratorFrajdyVm;
            _interface = interfacoinfdsa;
        }
        public override void Execute(object parameter)
        {
            if(_WFVM.Indeks >= 0)
            {
                _interface.DeleteQuiz(_WFVM.LQuizy[_WFVM.Indeks].quizId);
                _interface.DeleteListBoxQ(_WFVM.Indeks);
            }
            _WFVM.Indeks = -1;
        }
    }
}
