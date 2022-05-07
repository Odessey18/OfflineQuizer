using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizer
{
    public class Answer
    {
        public string text;
        public bool correct;
        public Answer(string Text, bool Correct)
        {
            text = Text;
            correct = Correct;
        }
    }
}
