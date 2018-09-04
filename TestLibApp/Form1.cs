using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SequenceLib;

namespace TestLibApp
{
    public partial class Form1 : Form
    {
        Sequence sequence;
        public Form1()
        {
            InitializeComponent();
            sequence = new Sequence();
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            
            sequence.Load("test");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Новый номер: " + sequence.NextValue());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Последний номер: " + sequence.GetCurrent().ToString());
        }
    }
}
