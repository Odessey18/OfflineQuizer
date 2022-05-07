using System;
using System.Collections.Generic;


namespace SimpleQuizer
{
    public class Quiz
    {
        public List<Question> Questions;
        public Question currentQuestion => Questions[currentQuestionIndex];
        private int currentQuestionIndex;
        public Quiz()
        {
            Questions = new List<Question>();
            currentQuestionIndex = 0;
        }
        public void NextQuestion()
        {
            if (currentQuestionIndex >= Questions.Count - 1) return;
            currentQuestionIndex++;
        }
        public void PriviousQuestion()
        {
            if (currentQuestionIndex <= 0) return;
            currentQuestionIndex--;
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

            Question w = new Question();
            w.Number = 2;
            w.Text = "To String Это?";
            w.Type = QuestionType.Choise;
            w.Answers.Add(new Answer("Метод", true));
            w.Answers.Add(new Answer("Класс ", false));
            quiz.Questions.Add(w);

            Question z = new Question();
            z.Number = 3;
            z.Text = "что из этого Лист?";
            z.Type = QuestionType.Choise;
            z.Answers.Add(new Answer("currentQuestion = new Question();", false));
            z.Answers.Add(new Answer("int i = 0 ", false));
            z.Answers.Add(new Answer("private List<Answer> userAnswres;", true));
            quiz.Questions.Add(z);

            Question x = new Question();
            x.Number = 4;
            x.Text = "Какой закон Ома?";
            x.Type = QuestionType.Choise;
            x.Answers.Add(new Answer("I = UR", true));
            x.Answers.Add(new Answer("S = Ut", false));
            x.Answers.Add(new Answer("A = FS", false));
            quiz.Questions.Add(x);

            return quiz;
        }
        #endregion
    }
}
