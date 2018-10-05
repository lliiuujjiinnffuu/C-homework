using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Order
    {
        public int numOfDetails = 0;
        public double orderTotalPrice = 0;
        public string orderNumber;
        public string customerName;
        public Order(string num, string name) {
            orderNumber = num;
            customerName = name;
        }
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public void CreateNewEntry(string kind, int number, double price) {
            orderDetails.Add(new OrderDetails(kind, number, price));
            numOfDetails++;
        }
        public void RemoveEntry(int num)
        {
            orderDetails.RemoveAt(num - 1);
            numOfDetails--;
        }
        public void ShowOrder()
        {
            orderTotalPrice = 0;
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
            Console.WriteLine("订单编号:" + orderNumber + " 客户:" + customerName+" 订单总价:"+orderTotalPrice);
            int tagNum = 1;
            foreach(OrderDetails ordertag in orderDetails)
            {
                Console.Write($"       条目{tagNum}: ");
                ordertag.ShowOrderDetails();
                tagNum++;
            }
        }
    }
}
