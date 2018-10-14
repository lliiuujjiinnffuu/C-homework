using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class SetForm : Form
    {

        public SetForm()
        {
            InitializeComponent();
            textBox1.Text = CreateForm.k.ToString();
            textBox2.Text = CreateForm.per1.ToString();
            textBox3.Text = CreateForm.per2.ToString();
            textBox4.Text = (CreateForm.th1 * 180 / Math.PI).ToString();
            textBox5.Text = (CreateForm.th2 * 180 / Math.PI).ToString();
            comboBox1.SelectedItem = "粉色";
            textBox6.Text = CreateForm.pen.Width.ToString();
        }
        private void textBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (sender == "")
            {
                if (e.KeyChar != '\b')//这是允许输入退格键
                {
                    if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字以及点好.
                    {
                        e.Handled = true;
                    }
                }
            }
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字以及点好.
                {
                    if (e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        dynamic text = ((dynamic)sender).Text;
                        if (text.Contains("."))
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (Double.Parse(textBox1.Text) >= 1.15)
                {
                    textBox1.Text = "1.15";
                }
                CreateForm.k = Double.Parse(textBox1.Text);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (Double.Parse(textBox2.Text) >= 0.75)
                {
                    textBox2.Text = "0.75";
                }
                CreateForm.per1 = Double.Parse(textBox2.Text);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (Double.Parse(textBox3.Text) >= 0.75)
                {
                    textBox3.Text = "0.75";
                }
                CreateForm.per2 = Double.Parse(textBox3.Text);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "") CreateForm.th1 = Double.Parse(textBox4.Text) * Math.PI / 180; ;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "") CreateForm.th2 = Double.Parse(textBox5.Text) * Math.PI / 180; ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "红色":
                    CreateForm.pen.Color = Color.Red;
                    break;
                case "粉色":
                    CreateForm.pen.Color = Color.Pink;
                    break;
                case "蓝色":
                    CreateForm.pen.Color = Color.Blue;
                    break;
                case "黄色":
                    CreateForm.pen.Color = Color.Yellow;
                    break;
                case "黑色":
                    CreateForm.pen.Color = Color.Black;
                    break;
                case "绿色":
                    CreateForm.pen.Color = Color.Green;
                    break;
                case "紫色":
                    CreateForm.pen.Color = Color.Purple;
                    break;
                case "灰色":
                    CreateForm.pen.Color = Color.Gray;
                    break;
                default:
                    break;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                if (Double.Parse(textBox6.Text) >= 20)
                {
                    textBox6.Text = "20";
                }
                CreateForm.pen.Width = float.Parse(textBox6.Text);
            }
        }
        public void Reset()
        {
            textBox1.Text = "0.91";
            textBox2.Text = "0.6";
            textBox3.Text = "0.7";
            textBox4.Text = "30";
            textBox5.Text = "20";
            textBox6.Text = "1.8";
            comboBox1.SelectedItem = "粉色";
        }
        public void RandomSet()
        {
            Random r = new Random();
            int i = r.Next(5000, 15000);
            double x = (double)i / 10000;
            textBox1.Text = x.ToString();
            i = r.Next(5500, 7500);
            x = (double)i / 10000;
            textBox2.Text = x.ToString();
            i = r.Next(5500, 7500);
            x = (double)i / 10000;
            textBox3.Text = x.ToString();
            i = r.Next(15, 75);
            x = (double)i / 1;
            textBox4.Text = x.ToString();
            i = r.Next(15, 75);
            x = (double)i / 1;
            textBox5.Text = x.ToString();
            i = r.Next(1000, 50000);
            x = (double)i / 10000;
            textBox6.Text = x.ToString();
            i = r.Next(0, 6);
            comboBox1.SelectedIndex = i;       
        }
    }
}
