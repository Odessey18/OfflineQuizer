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

        public static Quiz GetTestQuiz()
        {
            Quiz q = new Quiz();
            Questions = new List<Question>();
            Question q = new Question();
            q.Number = 1;
            q.QuestionText = "test";
            q.Type = QuestionType.Choise;
            q.Answers.Add("1 answer");
            q.Answers.Add("2 answer");
            q.Answers.Add("3 answer");

            quiz.Questions.Add(q);
            return quiz;
        }
    }
}
