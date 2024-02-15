using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Model
{
    class Encrypter
    {
        public static string Encrypt(string message, int key)
        {
            string encryptedMessage = "";

            foreach (char c in message)
            {
                if (Char.IsLetter(c))
                {
                    char encryptedChar = (char)(((int)Char.ToLower(c) - 97 + key) % 26 + 97);
                    encryptedMessage += Char.IsUpper(c) ? Char.ToUpper(encryptedChar) : encryptedChar;
                }
                else
                {
                    encryptedMessage += c;
                }
            }

            return encryptedMessage;
        }
        public static string Decrypt(string encryptedMessage, int key)
        {
            return Encrypt(encryptedMessage, 26 - key);
        }
        // Jeśli zawsze klucz będzie ten sam np 10 to wygodniej z tego korzystać:
        public static string Encrypt(string encryptedMessage)
        {
            return Encrypt(encryptedMessage, 10);
        }
        public static string Decrypt(string encryptedMessage)
        {
            return Decrypt(encryptedMessage, 10);
        }

        // Rozszyfrowywanie odpowiedzi: jeśli pierwsza litera ZASZYFROWANEGO CONTENTU ODPOWIEDZI to parzysta liczba to neguj odpowiedź
        // W argumentach funkcji podajesz najpierw EncryptedQuestionContent a potem questionAnswer
        public static bool DecryptAnswerBool(string answerContent, string answerAnswer)
        {
            bool finalValue = answerAnswer == "n" ? false : true;
            if ("QWERTYUIOPZXCVBNqwertyuiopzxcvbn".Contains(answerContent[0])) finalValue = !finalValue;
            return finalValue;
        }
        public static bool EncryptAnswerBool(string answerContent, bool answerAnswer)
        {
            bool finalValue = answerAnswer;
            if ("QWERTYUIOPZXCVBNqwertyuiopzxcvbn".Contains(answerContent[0])) finalValue = !finalValue;
            return finalValue;
        }
    }
}