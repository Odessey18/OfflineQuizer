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
        public List<Answer> correctAll;
        public List<Answer> allAll;
        public QuizRezult()
        {
            correctAll = new List<Answer>();
            allAll = new List<Answer>();
        }

    //public List<Answer> Answer;
}
}
