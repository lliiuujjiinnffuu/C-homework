using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderService
    {
        public int numOfOrder=0;
        public List<Order> orderList=new List<Order>();
        public void  AddOrder(Order order)
        {
            orderList.Add(order);
            numOfOrder++;
        }
        public void ShowOrder()
        {
            int orderNum = 1;
            Console.WriteLine();
             foreach(Order order in orderList)
            {
                Console.Write($"订单{orderNum}: ");
                order.ShowOrder();
                orderNum++;
            }
            Console.WriteLine();
        }
        public void Remove(int num) {
            orderList.RemoveAt(num-1);
            numOfOrder--;
        }
        public void FindByNum(string num)
        {
            var Target = orderList.Where(a => a.orderNumber.Contains(num));
            foreach (Order order in Target)
            {
                    Console.Write("       ");
                    order.ShowOrder();
            }
        }
        public void FindByName(string name)
        {
            var Target = orderList.Where(a => a.customerName.Contains(name));
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
            }
        }
        public void FindByKind(string kind)
        {
            var Target = orderList.Where(a => a.orderDetails.Exists(b=>b.kindOfGoods.Contains(kind)));
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
            }
        }
        public void FindTpMoreThan1000()
        {
            var Target = orderList.Where(a=>a.orderTotalPrice>=10000);  
            foreach (Order order in Target)
            {
                Console.Write("       ");
                order.ShowOrder();
            }
        }
    }
}
