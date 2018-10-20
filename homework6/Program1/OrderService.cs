using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    [Serializable]
    public class OrderService
    {
        XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
        string xmlFilename = "orderservice.xml";
        public int numOfOrder = 0;
        public List<Order> orderList = new List<Order>();
        public void AddOrder(Order order)
        {
            orderList.Add(order);
            numOfOrder++;
        }
        public void ShowOrder()
        {
            int orderNum = 1;
            Console.WriteLine();
            foreach (Order order in orderList)
            {
                Console.Write($"订单{orderNum}: ");
                order.ShowOrder();
                orderNum++;
            }
            Console.WriteLine();
        }
        public void Remove(int num)
        {
            if (num<=0||num>=orderList.Count)
            {
                return;
            }
            orderList.RemoveAt(num - 1);
            numOfOrder--;
        }
        public List<Order> FindByNum(string num)
        {
            var Target = orderList.Where(a => a.orderNumber.Contains(num));
            List<Order> list = new List<Order>();
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
                list.Add(order);
            }
            return list;
        }
        public List<Order> FindByName(string name)
        {
            var Target = orderList.Where(a => a.customerName.Contains(name));
            List<Order> list = new List<Order>();
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
                list.Add(order);
            }
            return list;
        }


        public List<Order> FindByKind(string kind)
        {
            var Target = orderList.Where(a => a.orderDetails.Exists(b => b.kindOfGoods.Contains(kind)));
            List<Order> list = new List<Order>();
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
                list.Add(order);
            }
            return list;
        }
        public void FindTpMoreThan1000()
        {
            var Target = orderList.Where(a => a.orderTotalPrice >= 10000);
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
            }
        }
        public void Export()
        {
            FileStream fs = new FileStream(xmlFilename, FileMode.Create);
            xmlser.Serialize(fs, this);
            fs.Close();
        }
        public OrderService Import()
        {
            FileStream fs = new FileStream(xmlFilename, FileMode.Open, FileAccess.Read);
            OrderService newOS = (OrderService)xmlser.Deserialize(fs);
            fs.Close();
            return newOS;
        }
    }
}
