using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;
using WpfApp1.Stores;
using WpfApp1.ViewModel;

namespace WpfApp1.Comms
{
    public class WczytajQ : commBase
    {
        private readonly WybieratorFrajdyVM _WFVM;
        private readonly Interface _interface;
        private readonly NavStore _navstore;
        public WczytajQ(WybieratorFrajdyVM wybieratorFrajdyVm, Interface interfacoinfdsa, NavStore navStore)
        {
            _WFVM = wybieratorFrajdyVm;
            _interface = interfacoinfdsa;
            _navstore = navStore;
        }

        public override void Execute(object parameter)
        {
            if(_WFVM.Indeks >= 0)
            {
                _interface.QuizId = _WFVM.LQuizy[_WFVM.Indeks].quizId;
                _navstore.CurrentVM = new GeneratorFrajdyVM(_interface);
                for (int i = 0; i < _interface.GetTable().Count; i++)
                {
                    _interface.EditListBox(new Dane(_interface.GetTable()[i].Type, _interface.GetTable()[i].Color, Encrypter.Decrypt(_interface.GetTable()[i].Content), Encrypter.DecryptAnswerBool(Encrypter.Decrypt(_interface.GetTable()[i].Content), _interface.GetTable()[i].Correct)? "✅" : "", _interface.GetTable()[i].Id), i);
                }
            }
            _WFVM.Indeks = -1;
        }
    }
}
