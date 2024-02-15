using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    public class ListBoxManager
    {
        private ObservableCollection<Dane> _quizy;
        private ObservableCollection<LoadQ> _lQuizy;

        private int quizId;

        public ListBoxManager()
        {
            _quizy = new ObservableCollection<Dane>();
            _lQuizy = new ObservableCollection<LoadQ>();
        }

        public void AddToListBox(Dane dane)
        {
            _quizy.Add(dane);
        }

        public void EditListBox(Dane dane, int i)
        {
            _quizy[i] = dane;
        }
        public void DeleteListBox(int i)
        {
            for(int j = 0; j < 5; j++)
            {
                _quizy.RemoveAt(i);
            }

        }
        public ObservableCollection<Dane> GetTable()
        {
            return _quizy;
        }

        public void SetTable(ObservableCollection<Dane> quiz)
        {
            _quizy = quiz;
        }

        //choose quiz model \/ \/ \/
        public void AddToListBoxQ(LoadQ loadq)
        {
            _lQuizy.Add(loadq);
        }

        public void DeleteListBoxQ(int i)
        {
            _lQuizy.RemoveAt(i);
        }

        public void SetTableQ(ObservableCollection<LoadQ> lQuizy)
        {
            _lQuizy = lQuizy;
        }

        public ObservableCollection<LoadQ> GetTableQ()
        {
            return _lQuizy;
        }

        public int QuizId
        {
            get { return quizId; }
            set { quizId = value; }
        }
    }
}
