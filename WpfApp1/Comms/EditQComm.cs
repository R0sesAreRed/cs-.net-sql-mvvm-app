using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Comms
{
    public class EditQComm : commBase
    {
        private readonly GeneratorFrajdyVM _GFVM;
        private readonly Interface _interface;
        private int SelIndex;
        public EditQComm(GeneratorFrajdyVM generatorFrajdyVm, Interface interfacoinfdsa)
        {
            _GFVM = generatorFrajdyVm;
            _interface = interfacoinfdsa;
        }
        public override void Execute(object parameter)
        {
            if(_GFVM.Indeks >= 0)
            {
                _GFVM.Editing = true;
                SelIndex = _GFVM.Indeks - (_GFVM.Indeks % 5);
                _GFVM.Pytanie = _GFVM.Quizy[SelIndex].Content;
                _GFVM.Odp1 = _GFVM.Quizy[SelIndex + 1].Content;
                _GFVM.O1 = _GFVM.Quizy[SelIndex + 1].Correct == "" ? false : true;
                _GFVM.Odp2 = _GFVM.Quizy[SelIndex + 2].Content;
                _GFVM.O2 = _GFVM.Quizy[SelIndex + 2].Correct == "" ? false : true;
                _GFVM.Odp3 = _GFVM.Quizy[SelIndex + 3].Content;
                _GFVM.O3 = _GFVM.Quizy[SelIndex + 3].Correct == "" ? false : true;
                _GFVM.Odp4 = _GFVM.Quizy[SelIndex + 4].Content;
                _GFVM.O4 = _GFVM.Quizy[SelIndex + 4].Correct == "" ? false : true;
            }
        }
    }
}
