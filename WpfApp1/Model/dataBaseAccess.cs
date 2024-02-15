using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace WpfApp1.Model
{
    public class dataBaseAccess
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\pawel\Desktop\BazaQuiz.db;Version=3");

        private static void WriteQuestion(SQLiteConnection conn, int qid, string content)
        {
            var command = conn.CreateCommand();
            /*
            command.CommandText = @"
            CREATE TABLE answers (
            id    INTEGER,
	        question_id   INTEGER,
	        content   TEXT,
	        correct   TEXT,
	        PRIMARY KEY(id AUTOINCREMENT)
            )";
            command.ExecuteNonQuery();
            command.CommandText = 
            @"
            CREATE TABLE questions (
            id    INTEGER,
	        quiz_id   INTEGER DEFAULT 1,
	        content   TEXT,
	        PRIMARY KEY(id AUTOINCREMENT)
            )";
            command.ExecuteNonQuery();
            command.CommandText = @"
            CREATE TABLE quizes (
            id    INTEGER,
        	Name  TEXT,
            PRIMARY KEY(id AUTOINCREMENT)
            )";
            command.ExecuteNonQuery();
            */
            command.CommandText =
            @"
                INSERT INTO questions (quiz_id, content)
                VALUES($quiz_id, $content)
            ";
            command.Parameters.AddWithValue("quiz_id", qid);
            command.Parameters.AddWithValue("$content", content);
            command.ExecuteNonQuery();

        }
        private static int GetLastInsertedId(SQLiteConnection conn)
        {
            var command = conn.CreateCommand();
            command.CommandText = "select last_insert_rowid()";
            long lastrowid64 = (long)command.ExecuteScalar();
            conn.Close();
            return (int)lastrowid64;
        }

        private static void WriteAnswer(SQLiteConnection conn, int qid, string content, bool correct)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO answers (question_id, content, correct)
                VALUES($question_id, $content, $correct)
            ";
            command.Parameters.AddWithValue("$question_id", qid);
            command.Parameters.AddWithValue("$content", content);
            command.Parameters.AddWithValue("$correct", correct ? "y" : "n");
            command.ExecuteNonQuery();
        }
        private static int GetAnswerId(SQLiteConnection conn, int qid)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
            @"
                SELECT MIN(id) FROM answers WHERE question_id = $id
            ";
            command.Parameters.AddWithValue("$id", qid);
            long AId = (long)command.ExecuteScalar();
            return (int)AId;
        }

        private static void updateAnswer(SQLiteConnection conn, int qid, string content, bool correct, int addid)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
            @"UPDATE answers
                SET content = $content, correct = $correct
                WHERE id = $qid
            ";
            command.Parameters.AddWithValue("$qid", GetAnswerId(conn, qid) + addid);
            command.Parameters.AddWithValue("$content", content);
            command.Parameters.AddWithValue("$correct", correct ? "y" : "n");
            command.ExecuteNonQuery();

        }

        private static void updateQuestion(SQLiteConnection conn, int qid, string content)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
            @"UPDATE questions SET content = $content WHERE id = $qid";
            command.Parameters.AddWithValue("$qid", qid);
            command.Parameters.AddWithValue("$content", content);
            command.ExecuteNonQuery();

        }

        private static void deleteRecord(SQLiteConnection conn, int qid)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
            @"DELETE FROM answers
            WHERE question_id = $qid;
            DELETE FROM questions
            WHERE id = $qid";
            command.Parameters.AddWithValue("$qid", qid);
            command.ExecuteNonQuery();
        }


        private static void deleteQuiz(SQLiteConnection conn, int qid)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
                @"DELETE FROM answers
                WHERE question_id IN 
                (
                    SELECT id
                    FROM questions
                    WHERE quiz_id = $qid
                );
                DELETE FROM questions
                WHERE quiz_id = $qid;
                DELETE FROM quizes
                WHERE id = $qid";
            command.Parameters.AddWithValue("$qid", qid);
            command.ExecuteNonQuery();
        }


        private static void readQuizes(SQLiteConnection conn, ObservableCollection<LoadQ> quizes)
        {
            SQLiteDataReader datareader;
            SQLiteCommand command;
            command = conn.CreateCommand();
            command.CommandText =
            @"
                SELECT * FROM quizes
            ";
            datareader = command.ExecuteReader();
            while (datareader.Read())
            { //pętla po każdym znalezionym quizie
                int quizId = datareader.GetInt32(0);
                string quizName = datareader.GetString(1);
                quizes.Add(new LoadQ(quizId, quizName));
            }
            //SELECT * FROM questions JOIN answers ON questions.id = answers.question_id WHERE questions.quiz_id = 1;
        }

        private static void readQuizContent(SQLiteConnection conn, ObservableCollection<Dane> quiz, int qid)
        {
            SQLiteDataReader datareader;
            SQLiteCommand command;
            command = conn.CreateCommand();
            command.CommandText =
            @"
            SELECT * FROM questions JOIN answers ON questions.id = answers.question_id WHERE questions.quiz_id = $qid;
            ";
            command.Parameters.AddWithValue("$qid", qid);
            datareader = command.ExecuteReader();
            while(datareader.Read())
            {
                int id = datareader.GetInt32(0);
                string content = datareader.GetString(2);
                quiz.Add(new Dane("Q: ", "Violet", content, "", id));
                quiz.Add(new Dane("A: ", "Green", datareader.GetString(5), datareader.GetString(6), id));
                datareader.Read();
                quiz.Add(new Dane("A: ", "Green", datareader.GetString(5), datareader.GetString(6), id));
                datareader.Read();
                quiz.Add(new Dane("A: ", "Green", datareader.GetString(5), datareader.GetString(6), id));
                datareader.Read();
                quiz.Add(new Dane("A: ", "Green", datareader.GetString(5), datareader.GetString(6), id));
            }
        }

        private static void addNewQuiz(SQLiteConnection conn, string name)
        {
            SQLiteCommand command = conn.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO quizes (Name)
                VALUES($Name)
            ";
            command.Parameters.AddWithValue("$Name", name);
            command.ExecuteNonQuery();

        }



        public void ReadQuizContent(ObservableCollection<Dane> quiz, int qid)
        {
            try
            {
                conn.Open();
                readQuizContent(conn, quiz, qid);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void DeleteQuiz(int qid)
        {
            try
            {
                conn.Open();
                deleteQuiz(conn, qid);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ReadQuizes(ObservableCollection<LoadQ> quizes)
        {
            try
            {
                conn.Open();
                readQuizes(conn, quizes);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int AddNewQuiz(string name)
        {
            try
            {
                conn.Open();
                addNewQuiz(conn, name);
                return GetLastInsertedId(conn);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }


        public void UpdateQuestion(int qid, string content)
        {
            try
            {
                conn.Open();
                updateQuestion(conn, qid, content);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void UpdateAnswer(int qid, string content, bool correct, int addid)
        {
            try
            {
                conn.Open();
                updateAnswer(conn, qid, content, correct, addid);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public int AddQuestion(int qid, string content)
        {
            try
            {
                conn.Open();
                WriteQuestion(conn, qid, content);
                return GetLastInsertedId(conn);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public void AddAnswer(int qid, string content, bool correct)
        {
            try
            {
                conn.Open();
                WriteAnswer(conn, qid, content, correct);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int qid)
        {
            try
            {
                conn.Open();
                deleteRecord(conn, qid);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
