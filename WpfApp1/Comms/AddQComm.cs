using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Comms
{
    public class AddQComm : commBase
    {
        private readonly GeneratorFrajdyVM _GFVM;
        private readonly Interface _interface;
        private int qid, id, editdid, editqid; //edit dsplay id, edit question id
        private readonly int DL = 20; //DisplayLength
        public AddQComm(GeneratorFrajdyVM generatorFrajdyVm, Interface interfacoinfdsa)
        {
            _GFVM = generatorFrajdyVm;
            _interface = interfacoinfdsa;
            qid = _interface.QuizId;
        }
        public override void Execute(object parameter)
        {
            if(_GFVM.Indeks >= 0 && _GFVM.Quizy.Count > 0 && _GFVM.Editing)
            {
                editqid = _GFVM.Quizy[_GFVM.Indeks / 5].Id;
                editdid = _GFVM.Indeks - (_GFVM.Indeks % 5);
                _interface.UpdateQuestion(editqid, Encrypter.Encrypt(_GFVM.Pytanie));
                _interface.EditListBox(new Dane(_GFVM.Quizy[editdid].Type, _GFVM.Quizy[editdid].Color, _GFVM.Pytanie.Length > DL ? _GFVM.Pytanie.Substring(0, DL) + "..." : _GFVM.Pytanie, "", _GFVM.Quizy[editdid].Id), editdid++);
                _interface.UpdateAnswer(editqid, Encrypter.Encrypt(_GFVM.Odp1), Encrypter.EncryptAnswerBool(_GFVM.Odp1, _GFVM.O1), 0);
                _interface.EditListBox(new Dane(_GFVM.Quizy[editdid].Type, _GFVM.Quizy[editdid].Color, _GFVM.Odp1.Length > DL ? _GFVM.Odp1.Substring(0, DL) + "..." : _GFVM.Odp1, _GFVM.O1 ? "✅" : "", _GFVM.Quizy[editdid].Id), editdid++);
                _interface.UpdateAnswer(editqid, Encrypter.Encrypt(_GFVM.Odp2), Encrypter.EncryptAnswerBool(_GFVM.Odp2, _GFVM.O2), 1);
                _interface.EditListBox(new Dane(_GFVM.Quizy[editdid].Type, _GFVM.Quizy[editdid].Color, _GFVM.Odp2.Length > DL ? _GFVM.Odp2.Substring(0, DL) + "..." : _GFVM.Odp2, _GFVM.O2 ? "✅" : "", _GFVM.Quizy[editdid].Id), editdid++);
                _interface.UpdateAnswer(editqid, Encrypter.Encrypt(_GFVM.Odp3), Encrypter.EncryptAnswerBool(_GFVM.Odp3, _GFVM.O3), 2);
                _interface.EditListBox(new Dane(_GFVM.Quizy[editdid].Type, _GFVM.Quizy[editdid].Color, _GFVM.Odp3.Length > DL ? _GFVM.Odp3.Substring(0, DL) + "..." : _GFVM.Odp3, _GFVM.O3 ? "✅" : "", _GFVM.Quizy[editdid].Id), editdid++);
                _interface.UpdateAnswer(editqid, Encrypter.Encrypt(_GFVM.Odp4), Encrypter.EncryptAnswerBool(_GFVM.Odp4, _GFVM.O4), 3);
                _interface.EditListBox(new Dane(_GFVM.Quizy[editdid].Type, _GFVM.Quizy[editdid].Color, _GFVM.Odp4.Length > DL ? _GFVM.Odp4.Substring(0, DL) + "..." : _GFVM.Odp4, _GFVM.O4 ? "✅" : "", _GFVM.Quizy[editdid].Id), editdid);
                _GFVM.Editing = false;
            }
            else
            {
                id = _interface.AddQuestion(qid, Encrypter.Encrypt(_GFVM.Pytanie));
                _interface.AddToListBox(new Dane("Q: ", "Violet", _GFVM.Pytanie.Length > DL ? _GFVM.Pytanie.Substring(0, DL) + "..." : _GFVM.Pytanie, "", id));
                _interface.AddAnswer(id, Encrypter.Encrypt(_GFVM.Odp1), Encrypter.EncryptAnswerBool(_GFVM.Odp1, _GFVM.O1));
                _interface.AddToListBox(new Dane("  A: ", "Green", _GFVM.Odp1.Length > DL ? _GFVM.Odp1.Substring(0, DL) + "..." : _GFVM.Odp1, _GFVM.O1 ? "✅" : "", id));
                _interface.AddAnswer(id, Encrypter.Encrypt(_GFVM.Odp2), Encrypter.EncryptAnswerBool(_GFVM.Odp2, _GFVM.O2));
                _interface.AddToListBox(new Dane("  A: ", "Green", _GFVM.Odp2.Length > DL ? _GFVM.Odp2.Substring(0, DL) + "..." : _GFVM.Odp2, _GFVM.O2 ? "✅" : "", id));
                _interface.AddAnswer(id, Encrypter.Encrypt(_GFVM.Odp3), Encrypter.EncryptAnswerBool(_GFVM.Odp3, _GFVM.O3));
                _interface.AddToListBox(new Dane("  A: ", "Green", _GFVM.Odp3.Length > DL ? _GFVM.Odp3.Substring(0, DL) + "..." : _GFVM.Odp3, _GFVM.O3 ? "✅" : "", id));
                _interface.AddAnswer(id, Encrypter.Encrypt(_GFVM.Odp4), Encrypter.EncryptAnswerBool(_GFVM.Odp4, _GFVM.O4));
                _interface.AddToListBox(new Dane("  A: ", "Green", _GFVM.Odp4.Length > DL ? _GFVM.Odp4.Substring(0, DL) + "..." : _GFVM.Odp4, _GFVM.O4 ? "✅" : "", id));
            }
            
            _GFVM.Pytanie = "";
            _GFVM.Odp1 = "";
            _GFVM.Odp2 = "";
            _GFVM.Odp3 = "";
            _GFVM.Odp4 = "";
            _GFVM.O1 = false;
            _GFVM.O2 = false;
            _GFVM.O3 = false;
            _GFVM.O4 = false;
            _GFVM.Indeks = -1;
            _GFVM.Quizy = _interface.GetTable();
        }
    }
}
