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
        int a;
        public DetailForm(Order or, Form1 f1)
        {
            InitializeComponent();
            listBindingSource.DataSource = or.orderDetails;
            this.f1 = f1;
            this.or = or;
            a = 0;
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
            a = 1;
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
            switch (a)
            {
                case 1:
                    ((FindForm)f1).RefreshNum();
                    break;
                case 0:
                    ((Form1)f1).RefreshNum();
                    break;
                default:
                    break;
            }
            f1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                OrderDetails ods = (OrderDetails)listBindingSource.Current;
                OrderService os = new OrderService();
                os.DeleteDetail(ods.ID);
                or.numOfDetails--;
                dataGridView2.Refresh();
                listBindingSource.RemoveAt(e.RowIndex);
                dataGridView2.Refresh();
                os.Update(or);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetails od = new OrderDetails("自己改", 0, 0);
            listBindingSource.Add(od);
            OrderService os = new OrderService();
            or.numOfDetails++;
            dataGridView2.Refresh();
            os.Update(or);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderService os = new OrderService();
            os.Update(or);
        }
    }
}
