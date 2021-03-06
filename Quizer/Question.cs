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
        Choise
    }

    [Serializable]
    public class Question
    {
        public int Number;
        public string Text;
        public QuestionType Type;
        public List<Answer> Answers;
        public List<Answer> UserAnswers;


        public Question()
        {
            Answers = new List<Answer>();
            UserAnswers = new List<Answer>();
        }
        
    }
}
