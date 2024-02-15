using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp1.Model
{
    public class Interface
    {
        private readonly dataBaseAccess _dataBaseAccess;
        private readonly ListBoxManager _listBoxManager;

        public string Name { get; }

        public Interface(string name)
        {
            Name = name; 
            _dataBaseAccess = new dataBaseAccess();
            _listBoxManager = new ListBoxManager();
        }

        public int AddQuestion(int qid, string content)
        {
            return _dataBaseAccess.AddQuestion(qid, content);
        }

        public void AddAnswer(int qid, string content, bool correct)
        {
            _dataBaseAccess.AddAnswer(qid, content, correct);
        }
        public void AddToListBox(Dane dane)
        {
            _listBoxManager.AddToListBox(dane);
        }
        public ObservableCollection<Dane> GetTable()
        {
            return _listBoxManager.GetTable();
        }

        public void UpdateQuestion(int qid, string content)
        {
            _dataBaseAccess.UpdateQuestion(qid, content);
        }

        public void UpdateAnswer(int qid, string content, bool correct, int addid)
        {
            _dataBaseAccess.UpdateAnswer(qid, content, correct, addid);
        }

        public void EditListBox(Dane dane, int i)
        {
            _listBoxManager.EditListBox(dane, i);
        }

        public void Delete(int qid)
        {
            _dataBaseAccess.Delete(qid);
        }
        public void DeleteListBox(int i)
        {
            _listBoxManager.DeleteListBox(i);
        }

        public void SetTable(ObservableCollection<Dane> a)
        {
            _listBoxManager.SetTable(a);
        }


        public int AddNewQuiz(string name)
        {
            return _dataBaseAccess.AddNewQuiz(name);

        }

        public void AddToListBoxQ(LoadQ loadq)
        {
            _listBoxManager.AddToListBoxQ(loadq);
        }

        public void DeleteListBoxQ(int i)
        {
            _listBoxManager.DeleteListBoxQ(i);
        }

        public ObservableCollection<LoadQ> GetTableQ()
        {
            return _listBoxManager.GetTableQ();
        }

        public void ReadQuizes(ObservableCollection<LoadQ> quizes)
        {
            _dataBaseAccess.ReadQuizes(quizes);
        }

        public void DeleteQuiz(int i)
        {
            _dataBaseAccess.DeleteQuiz(i);
        }

        public void SetTableQ(ObservableCollection<LoadQ> a)
        {
            _listBoxManager.SetTableQ(a);
        }

        public void ReadQuizContent(ObservableCollection<Dane> quiz, int qid)
        {
            _dataBaseAccess.ReadQuizContent(quiz, qid);
        }

        public int QuizId
        {
            get { return _listBoxManager.QuizId; }
            set { _listBoxManager.QuizId = value; }
        }
    }
}
