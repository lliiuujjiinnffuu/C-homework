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
    public partial class Form1 : Form
    {
        List<Order> orderlist = new List<Order>();
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
           InitializeComponent();     
            orderlist.Add(new Order("EDX541253", "Andy Lau"));
            orderlist.Add(new Order("DFDSC34234", "Jack Bree"));
            orderlist.Add(new Order("LLP234234", "Charie Do"));
            orderlist[0].CreateNewEntry("可乐", 1500, 3.5);
            orderlist[0].CreateNewEntry("鸡翅", 552, 4.5);
            orderlist[0].CreateNewEntry("鸡腿", 300, 6);
            orderlist[1].CreateNewEntry("凳子", 25, 32.5);
            orderlist[1].CreateNewEntry("公鸡", 20, 53);
            orderlist[2].CreateNewEntry("鸡腿", 330, 6.6);
            orderlist[2].CreateNewEntry("冰棍", 560, 3.5);
            orderlist[2].CreateNewEntry("香蕉", 10000, 1.5);
            orderBindingSource.DataSource = orderlist;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >=0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            else if (e.ColumnIndex==5&&e.RowIndex>=0)
            {
                DetailForm detailform = new DetailForm(orderlist[e.RowIndex],this);
                this.Hide();
                detailform.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           orderBindingSource.Add(new Order("自己改", "自己改"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindForm ff = new FindForm(orderlist, this);
            this.Hide();
            ff.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
