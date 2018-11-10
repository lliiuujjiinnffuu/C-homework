using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orders;

namespace Program1
{
    public partial class FindForm : Form
    {
        List<Order> orders;
        List<Order> Currentorders;
        Form1 f1;
        public FindForm(List<Order> orders, Form1 f1)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.orders = orders;
            this.f1 = f1;
            bindingSource1.DataSource = orders;
            comboBox1.SelectedItem = "顾客姓名";
            Currentorders = orders;
        }

        private void FindForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            switch (comboBox1.SelectedItem)
            {
                case "顾客姓名":
                    var target1= orders.Where(a => a.customerName.Contains(textBox1.Text));
                    bindingSource1.DataSource = target1;
                    Currentorders = new List<Order>();
                    foreach (var or in target1)
                    {
                        Currentorders.Add(or);
                    }
                    break;
                case "订单编号":
                    var target2 = orders.Where(a => a.orderNumber.Contains(textBox1.Text));
                    bindingSource1.DataSource = target2;
                    Currentorders = new List<Order>();
                    foreach (var or in target2)
                    {
                        Currentorders.Add(or);
                    }
                    break;
                case "商品种类":
                    var target3 = orders.Where(a => a.orderDetails.Exists(b => b.kindOfGoods.Contains(textBox1.Text)));
                    bindingSource1.DataSource = target3;
                    Currentorders = new List<Order>();
                    foreach (var or in target3)
                    {
                        Currentorders.Add(or);
                    }
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex==4)
            {
                DetailForm df = new DetailForm(Currentorders[e.RowIndex],this);
                this.Hide();
                df.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
