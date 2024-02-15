using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Model
{
    public class Dane
    {
        public string Type { get; }
        public string Color { get; }
        public string Content { get; }
        public string Correct { get; }

        public int Id {get;}


        public Dane(string type, string color, string content, string correct, int id)
        {
            Type = type;
            Color = color;
            Content = content;
            Correct = correct;
            Id = id;
        }

    }
}
