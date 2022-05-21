using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizer
{
    public enum QuestionType
    {
        MultiChoise,
        Choise,
        Open
    }

    [Serializable]
    public class Question
    {
        public int Number;
        public string Text;
        public QuestionType Type;
        public List<Answer> Answers;
        public int CorrectAswerAmount;

        public Question()
        {
            Answers = new List<Answer>();
        }
        
    }
}
