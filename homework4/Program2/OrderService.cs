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
            foreach (Order order in orderList)
            {
                if (order.orderNumber.Contains(num))
                {
                    Console.Write("       ");
                    order.ShowOrder();
                }
            }
        }
        public void FindByName(string name)
        {
            foreach (Order order in orderList)
            {
                if (order.customerName.Contains(name))
                {
                    Console.Write("       ");
                    order.ShowOrder();
                }
            }
        }
        public void FindByKind(string kind)
        {
            foreach (Order order in orderList)
            {
                bool isContained = false;
                foreach (OrderDetails details in order.orderDetails)
                {
                    if (details.kindOfGoods.Contains(kind))
                    {
                        isContained = true;
                    }
                }
                if (isContained)
                {
                    Console.Write("       ");
                    order.ShowOrder();
                }
            }
        }
    }
}
