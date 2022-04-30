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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            
        }
        #region Debug
        private void открытьТестовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz q = Quiz.GetTestQuiz();
            ShowQuestion(q.Questions[0]);

        }
        #endregion
        private void ShowQuestion(Question question)
        {
            
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
                t.Text = question.Answers[i].text + question.Answers[i].correct.ToString();
                tableLayoutPanel1.Controls.Add(t, 1, i);
            }
            


        }
    }
}
