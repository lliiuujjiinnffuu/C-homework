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
    public partial class DetailForm : Form
    {
        Form f1;
        Order or;
        public DetailForm(Order or,Form1 f1)
        {
            InitializeComponent();
            listBindingSource.DataSource = or.orderDetails ;
            this.f1 = f1;
            this.or = or;
            this.StartPosition = FormStartPosition.CenterScreen;
            orderBindingSource.DataSource = or;
        }
        public DetailForm(Order or, FindForm ff)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            listBindingSource.DataSource = or.orderDetails;
            this.f1 = ff;
            this.or = or;
            orderBindingSource.DataSource = or;
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ErrorForm er = new ErrorForm();
            er.ShowDialog();
        }

        private void DetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex==4)
            {
                listBindingSource.RemoveAt(e.RowIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBindingSource.Add(new OrderDetails("自己改",0,0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
