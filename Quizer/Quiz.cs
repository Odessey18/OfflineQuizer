using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleQuizer
{
    [Serializable]
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
        public Quiz(string path)
        {
            Deserialize(path);
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
        public static Quiz GetTestQuiz11()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.Text = "Кто придумал планитарную модель атома";
            q.Type = QuestionType.Choise;
            q.Answers.Add(new Answer("Ньютон", false));
            q.Answers.Add(new Answer("Резерфорд", true));
            q.Answers.Add(new Answer("Томсон", false));
            quiz.Questions.Add(q);

            Question w = new Question();
            w.Number = 2;
            w.Text = "Какие параметры необходимы для выполнения работы?";
            w.Type = QuestionType.Choise;
            w.Answers.Add(new Answer("Тело, Сила, Перемещение ", true));
            w.Answers.Add(new Answer("Плотность, Масса, Объем", false));
            quiz.Questions.Add(w);

            Question z = new Question();
            z.Number = 3;
            z.Text = "Для чего нужны простые механизмы";
            z.Type = QuestionType.Choise;
            z.Answers.Add(new Answer("Для Крутоты", false));
            z.Answers.Add(new Answer("Для выигрыша в Работе ", false));
            z.Answers.Add(new Answer("Для выигрыша в Силе", true));
            quiz.Questions.Add(z);

            Question x = new Question();
            x.Number = 4;
            x.Text = "Какие радиактивные вещества нужны для получения Ядерной энергии?";
            x.Type = QuestionType.Choise;
            x.Answers.Add(new Answer("U235, Pu239", true));
            x.Answers.Add(new Answer("U239, Pu239", false));
            x.Answers.Add(new Answer("U235, Np239", false));
            quiz.Questions.Add(x);

            return quiz;
        }
            #endregion
        public void Save(string path)
        {
            Serialize(path);
        }
        public void Load(string path)
        {
            Deserialize(path);
        }
        private void Serialize(string path)
        {
            Stream file = File.Open(path, FileMode.OpenOrCreate);

            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(file, Questions);
            file.Close();
        }
        private void Deserialize(string path)
        {
            Stream file = File.Open(path, FileMode.OpenOrCreate);

            BinaryFormatter binary = new BinaryFormatter();
            Questions = (List<Question>)binary.Deserialize(file);
            file.Close();
        }
    }
}
