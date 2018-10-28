using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//订单的组成部分,以及订单的生成
namespace Orders
{
    [Serializable]
    public class Order
    {
        public int numOfDetails { set; get; }
        public double orderTotalPrice { set; get; }
        public string orderNumber { set; get; }
        public string customerName { set; get; }
        public List<OrderDetails> orderDetails { set; get; }
        public Order()
        {
            orderDetails = new List<OrderDetails>();
            numOfDetails = 0;
            orderTotalPrice = 0;
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
        }
        public Order(string num, string name)
        {
            orderDetails = new List<OrderDetails>();
            numOfDetails = 0;
            orderTotalPrice = 0;
            orderNumber = num;
            customerName = name;
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
        }
        public void CreateNewEntry(string kind, int number, double price)
        {
            orderDetails.Add(new OrderDetails(kind, number, price));
            numOfDetails++;
            orderTotalPrice = 0;
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
        }
    }
}

