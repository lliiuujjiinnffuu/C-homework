using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{

    class Program
    {
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            List<Order> orderlist = new List<Order>();
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
            }

        }
    }
}
