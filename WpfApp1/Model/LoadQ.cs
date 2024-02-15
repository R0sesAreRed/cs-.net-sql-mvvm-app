using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Model
{
    public class LoadQ
    {
        public int quizId { get; }
        public string quizName { get; }

        public LoadQ(int quizId, string quizName)
        {
            this.quizId = quizId;
            this.quizName = quizName;
        }
    }
}
