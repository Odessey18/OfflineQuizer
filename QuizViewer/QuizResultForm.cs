using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleQuizer.Viewer
{
    public partial class QuizResultForm : Form
    {

        private QuizRezult result;

        public QuizResultForm(QuizRezult result)
        {
            InitializeComponent();

            this.result = result;

            tableLayoutPanel1.RowCount = result.allAll;

            ShowResult();

        }
        private void ShowResult()
        {
            int m = 0;
            //label1.Text = "верно" + result.correctAll.ToString() + " из " + result.allAll.ToString();
            //label6.Text = result.quizQuestion[0].UserAnswers[0].text;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < result.quizQuestion.Count; i++)
            {


                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / result.quizQuestion.Count));

                
            }
            for (int i = 0; i < result.quizQuestion.Count; i++)
            {
                Label z = new Label();
                
                z.Width = tableLayoutPanel1.GetColumnWidths()[0];
                m = i + 1;
                z.Text = m.ToString();
                tableLayoutPanel1.Controls.Add(z, 0, i);

                TextBox t = new TextBox();
                t.Multiline = true;
                t.Height = tableLayoutPanel1.GetRowHeights()[0];
                t.Width = tableLayoutPanel1.GetColumnWidths()[1];
                t.Text = result.quizQuestion[i].Text;
                tableLayoutPanel1.Controls.Add(t, 1, i);

                TextBox x = new TextBox();
                x.Height = tableLayoutPanel1.GetRowHeights()[0];
                x.Width = tableLayoutPanel1.GetColumnWidths()[2];
                x.Text = result.quizQuestion[i].UserAnswers[0].text;
                tableLayoutPanel1.Controls.Add(x, 2, i);

                TextBox y = new TextBox();
                y.Height = tableLayoutPanel1.GetRowHeights()[0];
                y.Width = tableLayoutPanel1.GetColumnWidths()[3];
                y.Text = result.quizQuestion[i].UserAnswers[0].correct.ToString();                  ///коректные ответы
                tableLayoutPanel1.Controls.Add(y, 3, i);

            }
        }


    }
}
