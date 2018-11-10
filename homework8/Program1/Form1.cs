using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<Order> orderlist = new List<Order>();
        XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            orderlist.Add(new Order("20181221000", "Andy Dee", "18954156160"));
            orderlist.Add(new Order("20181221001", "Andy Lau", "10000000000"));
            orderlist.Add(new Order("20181221001", "Jack Bree", "13254156160"));
            orderlist.Add(new Order("20180423002", "Charie Do", "14354156160"));
            orderlist.Add(new Order("20130111002", "Ku Lau", "17354156160"));
            orderlist[0].CreateNewEntry("可乐", 1500, 3.5);
            orderlist[0].CreateNewEntry("鸡翅", 552, 4.5);
            orderlist[0].CreateNewEntry("鸡腿", 300, 6);
            orderlist[1].CreateNewEntry("凳子", 25, 32.5);
            orderlist[1].CreateNewEntry("公鸡", 20, 53);
            orderlist[2].CreateNewEntry("鸡腿", 330, 6.6);
            orderlist[2].CreateNewEntry("冰棍", 560, 3.5);
            orderlist[2].CreateNewEntry("香蕉", 10000, 1.5);
            orderlist[3].CreateNewEntry("公鸡", 20, 53);
            orderlist[3].CreateNewEntry("鸡腿", 330, 6.6);
            orderlist[4].CreateNewEntry("凳子", 25, 32.5);
            orderlist[4].CreateNewEntry("公鸡", 20, 53);
            orderlist[4].CreateNewEntry("鸡腿", 330, 6.6);
            orderBindingSource.DataSource = orderlist;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
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
            Order A = new Order("自己改", "自己改", "自己改");
            A.CreateNewEntry("0",0,0);
            orderBindingSource.Add(A);
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
        public static bool CheckPhoneNumber(string Str)
        {
            //if (Str.Count() != 11)
            //{
            //    return false;
            //}
            Regex rg = new Regex(@"^1[34578][0-9]{9}$");
            return rg.IsMatch(Str);
        }
        public bool Checkliushuihao(string Str)
        {
            string numString = Regex.Replace(Str, @".*(?=.{3})", "");
            List<String> others = new List<String>();
            foreach (Order order in orderlist)
            {
                others.Add(Regex.Replace(order.orderNumber, @".*(?=.{3})", ""));
            }
            others.Remove(numString);
            foreach (string Num in others)
            {
                if (numString == Num)
                {
                    return false;
                }
            }
            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Order order in orderlist)
            {
                List<Order> others = new List<Order>(orderlist);
                others.Remove(order);
                order.checkResult = "";
                foreach (Order order1 in others)
                {
                    if (order1.orderNumber == order.orderNumber)
                    {
                        order.checkResult = "订单重复";
                    }
                }
                if (order.checkResult != "订单重复")
                {
                    if (Checktime(order.orderNumber))
                    {
                        order.checkResult += " 订单格式正确";
                        if (!Checkliushuihao(order.orderNumber))
                        {
                            order.checkResult += "但流水号重复";
                        }
                    }
                    else
                    {
                        order.checkResult += "订单格式错误";
                    }
                }
                if (CheckPhoneNumber(order.phoneNumber))
                {
                    order.checkResult += " 电话号码正确";
                }
                else
                {
                    order.checkResult += " 电话号码不正确";
                }
            }
            dataGridView1.Refresh();
        }
        public void Export()
        {
            FileStream fs = new FileStream("orders.xml", FileMode.Create);
            xmlser.Serialize(fs, orderlist);
            XmlDocument xDoc = new XmlDocument();
            fs.Close();
            xDoc.Load("orders.xml");
            FileStream fs1 = new FileStream("orders.html", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs1, Encoding.Default);
            StringWriter sw = new StringWriter();
            XslCompiledTransform xslTrans = new XslCompiledTransform();
            xslTrans.Load("..//..//..//xmlTohtml.xslt");
            xslTrans.Transform(xDoc.CreateNavigator(), new XsltArgumentList(), sw);
            streamWriter.Write(sw);
            streamWriter.Flush();
            streamWriter.Close();
            fs1.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Export();
        }
    }
}
