using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double a = 0, b = 0,c =0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = a * b;
            label1.Text = c.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            b = double.Parse(textBox2.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
