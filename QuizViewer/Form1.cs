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

        //private List<RadioButton> questionControls;
        private List<Answer> userAnswres;
        private List<RadioButton> radioButtons;


        private Quiz currentQuiz;
        public Form1()
        {
            InitializeComponent();
            //questionControls = new List<RadioButton>();
            userAnswres = new List<Answer>();
            radioButtons = new List<RadioButton>();


        }
        private void CorectnessButton_Click(object sender, EventArgs e)
        {
            CheckQuestion();
            
        }
        private void CheckQuestion()
        {
            GetUserInput();
            CheckUserAnswer();
        }
        private void CheckUserAnswer()
        {
            int userCorrectAnswer = 0;
            for (int i = 0; i < userAnswres.Count; i++)
            {
                if (userAnswres[i].correct == true)
                {
                    userCorrectAnswer++;
                }
                if (userAnswres[i].correct == false)
                {
                    userCorrectAnswer = 0;
                    break;
                }
     
            }
            if (userCorrectAnswer != 0 && currentQuiz.currentQuestion.CorrectAswerAmount == userCorrectAnswer)
            {
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show("Mistake");

            }
        }
        private void GetUserInput()
        {
            userAnswres.Clear();

            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].Checked == true)
                {
                    userAnswres.Add(currentQuiz.currentQuestion.Answers[i]);

                }
                
            }
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


            radioButtons.Clear();

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
                //t.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte));
                tableLayoutPanel1.Controls.Add(t, 1, i);

                radioButtons.Add(z);
            }

            radioButtons.Clear();
            for(int i = 0; i < question.Answers.Count; i++)
            {
                RadioButton r = new RadioButton();

                r.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
                r.Height = tableLayoutPanel1.GetRowHeights()[0];
                r.Width = tableLayoutPanel1.GetColumnWidths()[1];
                r.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

                tableLayoutPanel1.Controls.Add(r, 0, i);
                radioButtons.Add(r);
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
    }
}
