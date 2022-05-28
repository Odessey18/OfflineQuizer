using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleQuizer;

namespace SimpleQuizer.Viewer
{
    public partial class Form1 : Form
    {

        private List<RadioButton> questionControls;
        //private List<Answer> userAnswres;
        private QuizRezult result;
        private Quiz currentQuiz;
        public Form1()
        {
            InitializeComponent();

            questionControls = new List<RadioButton>();
            //userAnswres = new List<Answer>();
            result = new QuizRezult();


        }
        private void CorectnessButton_Click(object sender, EventArgs e)
        {
           
      
            if (currentQuiz == null) return;
               
               
            GetUserInput();
            CheckUserAnswer();

        

            if (currentQuiz.currentQuestion.Number == currentQuiz.Questions.Count)
            {
                ShowResult();

            }

            currentQuiz.NextQuestion();
            ShowQuestion(currentQuiz.currentQuestion);



        }
        private void CheckUserAnswer()
        {
            for (int i = 0; i < currentQuiz.currentQuestion.UserAnswers.Count; i++)
            {
                if(currentQuiz.currentQuestion.UserAnswers[i].correct == true)
                {

                    result.correctAll++;
                   // result.correctAll.Add(currentQuiz.currentQuestion.UserAnswers[i]);
                }

                //result.allAll.Add(currentQuiz.currentQuestion.UserAnswers[i]);

            }


            //MessageBox.Show(savedAnswers.allAll.Count.ToString());

        }
        private void GetUserInput()
        {
            currentQuiz.currentQuestion.UserAnswers.Clear();

            for (int i = 0; i < questionControls.Count; i++)
            {
                if (questionControls[i].Checked == true)
                {
                    currentQuiz.currentQuestion.UserAnswers.Add(currentQuiz.currentQuestion.Answers[i]);

                }
                ////
            }
            result.quizQuestion.Add(currentQuiz.currentQuestion);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //To Do
            
        }
        #region Debug
        private void открытьТестовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentQuiz = Quiz.GetTestQuiz();
            ShowQuestion(currentQuiz.currentQuestion);
        }
        #endregion
        private void Next_button_Click(object sender, EventArgs e)
        {
            if (currentQuiz == null) return;
            currentQuiz.NextQuestion();
            ShowQuestion(currentQuiz.currentQuestion);
            
            

        }

        private void Last_button_Click(object sender, EventArgs e)
        {
            if (currentQuiz == null) return;
            currentQuiz.PriviousQuestion();
            ShowQuestion(currentQuiz.currentQuestion);
            
        }
        private void ShowQuestion(Question question)
        {
            

            questionControls.Clear();

            NumberLabel.Text = "Вопрос " + question.Number.ToString();
            AnswerText.Text = question.Text;
            if (question.Type == QuestionType.Choise)
            {
                InfoLabel.Text = "Выберите выриант ответа";
            }
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = question.Answers.Count;

            for(int i = 0; i < question.Answers.Count; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / question.Answers.Count));
            }


            for (int i = 0; i < question.Answers.Count; i++)
            {
                RadioButton z = new RadioButton();
                z.Height = tableLayoutPanel1.GetRowHeights()[0];
                z.Width = tableLayoutPanel1.GetColumnWidths()[0];
                tableLayoutPanel1.Controls.Add(z, 0, i);

                TextBox t = new TextBox();
                t.Multiline = true;
                t.Height = tableLayoutPanel1.GetRowHeights()[0];
                t.Width = tableLayoutPanel1.GetColumnWidths()[1];
                t.Text = question.Answers[i].text ;
                tableLayoutPanel1.Controls.Add(t, 1, i);

                questionControls.Add(z);
            }
            


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz.GetTestQuiz().Save("TestQuiz.tqf");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if( openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                currentQuiz = new Quiz(openFileDialog1.FileName);
                
            }
            ShowQuestion(currentQuiz.currentQuestion);
        }

        private void ShowResult()
        {
            QuizResultForm f = new QuizResultForm(result);
            f.Show();
        }
        private void Проверить_button1_Click(object sender, EventArgs e)
        {
            ShowResult();
        }
    }
}
