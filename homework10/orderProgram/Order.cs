using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    [Serializable]
    public class Order
    {
        public int numOfDetails { set; get; }
        public double orderTotalPrice { set; get; }

        [Key]
        public string orderNumber { set; get; }
        public string customerName { set; get; }
        public string checkResult { set; get; }
        public string phoneNumber { set; get; }
        public List<OrderDetails> orderDetails { set; get; }
        public Order()
        {
            orderDetails = new List<OrderDetails>();
            numOfDetails = 0;
            orderTotalPrice = 0;
            phoneNumber = "0";
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
        }
        public Order(string num, string name, string phone)
        {
            orderDetails = new List<OrderDetails>();
            numOfDetails = 0;
            orderTotalPrice = 0;
            orderNumber = num;
            customerName = name;
            phoneNumber = phone;
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
        }
        public Order(string name, string phone)
        {
            OrderService os = new OrderService();
            List<OrderDetails> odl = os.GetAllOrderDetails();
            int a = 0;
            for (a = 0; a < int.MaxValue; a++)
            {
                bool exist = false;
                foreach (OrderDetails detail in odl)
                {
                    if (detail.ID == "LJF" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + a.ToString())
                    {
                        exist = true;
                    }
                }

                if (!exist)
                {
                    break;
                }
            }

            this.orderNumber = "LJF" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + a.ToString();
            orderDetails = new List<OrderDetails>();
            numOfDetails = 0;
            orderTotalPrice = 0;
            customerName = name;
            phoneNumber = phone;
            foreach (OrderDetails ordertag in orderDetails)
            {
                orderTotalPrice += ordertag.totalPrice;
            }
        }
        public void CreateNewEntry(string ID, string kind, int number, double price)
        {
            orderDetails.Add(new OrderDetails(ID, kind, number, price));
            numOfDetails++;
            orderTotalPrice = 0;
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

