using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizer
{
    [Serializable]
    public class QuizRezult
    {
        public int correctAll;
        public int allAll;

        public List<Question> quizQuestion;
        public QuizRezult()
        {

            quizQuestion = new List<Question>();


        }

    //public List<Answer> Answer;
}
}
