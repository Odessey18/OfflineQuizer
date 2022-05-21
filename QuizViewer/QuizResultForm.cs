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

            tableLayoutPanel1.RowCount = result.allAll.Count;
            label1.Text = "верно" + result.correctAll.Count.ToString() + " из " + result.allAll.Count.ToString();
        }
       

        
    }
}
