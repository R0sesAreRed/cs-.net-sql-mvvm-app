using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Comms
{
    public class DeleteQComm : commBase
    {
        private readonly GeneratorFrajdyVM _GFVM;
        private readonly Interface _interface;
        private int editdid, editqid; //edit dsplay id, edit question id
        public DeleteQComm(GeneratorFrajdyVM generatorFrajdyVm, Interface interfacoinfdsa)
        {
            _GFVM = generatorFrajdyVm;
            _interface = interfacoinfdsa;
        }
        public override void Execute(object parameter)
        {
            if (_GFVM.Indeks >= 0 && _GFVM.Quizy.Count > 0)
            {
                editqid = _GFVM.Quizy[_GFVM.Indeks].Id;
                editdid = _GFVM.Indeks - (_GFVM.Indeks % 5);
                _interface.Delete(editqid);
                _interface.DeleteListBox(editdid);
            }
        }
    }
}
