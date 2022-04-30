using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer
{
    public enum QuestionType
    {
        Choise,
        open
    }
    public class Question
    {
        public int Number;
        public string QuastionText;
        public QuestionType Type;
        public List<string> Answer;


        
    }
}
