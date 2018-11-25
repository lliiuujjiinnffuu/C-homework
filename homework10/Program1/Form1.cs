using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Serialization;
using Orders;
namespace Program1
{
    public partial class Form1 : Form
    {
        OrderService os = new OrderService();
        List<Order> orderlist = new List<Order>();
        XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();



            orderlist=os.GetAllOrders();
            orderBindingSource.DataSource = os.GetAllOrders();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            orderlist = os.GetAllOrders();
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                Order current= (Order)orderBindingSource.Current;
                os.DeleteOrder(current.orderNumber);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                DetailForm detailform = new DetailForm(orderlist[e.RowIndex], this);
                this.Hide();
                detailform.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order A = new Order("自己改", "自己改");
            A.CreateNewEntry("0", 0, 0);
            orderBindingSource.Add(A);
            OrderDB odb = new OrderDB();
            odb.Order.Add(A);
            odb.SaveChanges();
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
        public static bool Checktime(string Str)
        {
            if (Str.Count() != 11)
            {
                return false;
            }
            string timeString = Regex.Replace(Str, @"(?<=.{8}).*", "");
            timeString = timeString.Insert(4, "-");
            timeString = timeString.Insert(7, "-");
            DateTime datetime = new DateTime();
            return DateTime.TryParse(timeString, out datetime);
        }
        public void RefreshNum()
        {
            orderBindingSource.DataSource = os.GetAllOrders();
            dataGridView1.Refresh();
        }
        public static bool CheckPhoneNumber(string Str)
        {
            //if (Str.Count() != 11)
            //{
            //    return false;
            //}
            Regex rg = new Regex(@"^1[34578][0-9]{9}$");
            return rg.IsMatch(Str);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            orderlist.Clear();
            orderlist.Add(new Order("20181221000", "Andy Dee", "18954156160"));
            orderlist.Add(new Order("20181221001", "Andy Lau", "10000000000"));
            orderlist.Add(new Order("20181221002", "Jack Bree", "13254156160"));
            orderlist.Add(new Order("20180423002", "Charie Do", "14354156160"));
            orderlist.Add(new Order("20130111002", "Ku Lau", "17354156160"));
            orderlist[0].CreateNewEntry("0001", "可乐", 1500, 3.5);
            orderlist[0].CreateNewEntry("0002", "鸡翅", 552, 4.5);
            orderlist[0].CreateNewEntry("0003", "鸡腿", 300, 6);
            orderlist[1].CreateNewEntry("0004", "凳子", 25, 32.5);
            orderlist[1].CreateNewEntry("0005", "公鸡", 20, 53);
            orderlist[2].CreateNewEntry("0006", "鸡腿", 330, 6.6);
            orderlist[2].CreateNewEntry("0007", "冰棍", 560, 3.5);
            orderlist[2].CreateNewEntry("0008", "香蕉", 10000, 1.5);
            orderlist[3].CreateNewEntry("0009", "公鸡", 20, 53);
            orderlist[3].CreateNewEntry("0010", "鸡腿", 330, 6.6);
            orderlist[4].CreateNewEntry("0011", "凳子", 25, 32.5);
            orderlist[4].CreateNewEntry("0012", "公鸡", 20, 53);
            orderlist[4].CreateNewEntry("0013", "鸡腿", 330, 6.6);
            foreach (Order order in orderlist)
            {
                bool existed = false;
                List<Order> orders = os.GetAllOrders();
                foreach (Order ordered in orders)
                {
                    if (ordered.orderNumber == order.orderNumber)
                    {
                        existed = true;
                        break;
                    }
                }
                if (!existed)
                {
                    os.Add(order);
                }
                orderBindingSource.DataSource = os.GetAllOrders();
            }
        }
    }
}
