using System;
using System.Collections.Generic;


namespace SimpleQuizer
{
    public class Quiz
    {
        public List<Question> Questions;
        public Quiz()
        {
            Questions = new List<Question>();
        }
        #region Debug
        public static Quiz GetTestQuiz()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.Text = "Для чего инжектор?";
            q.Type = QuestionType.Choise;
            q.Answers.Add(new Answer("для фильтрации газа", false));
            q.Answers.Add(new Answer("для подачи топлива ", true));
            q.Answers.Add(new Answer("для уменьшения сопротивления воздуха", false));
           
            

            quiz.Questions.Add(q);
            return quiz;
        }
        #endregion
    }
}
