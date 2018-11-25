using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Orders
{
    [Serializable]
    public class OrderDetails
    {
        [Key]
        public string ID { set; get; }
        public string kindOfGoods { set; get; }
        public int numberOfGoods { set; get; }
        public double price { set; get; }
        public double totalPrice { set; get; }
        public OrderDetails() { }
        public OrderDetails(string ID, string kind, int num, double price)
        {
            this.ID = ID;
            kindOfGoods = kind;
            numberOfGoods = num;
            this.price = price;
            totalPrice = num * price;
        }
        public OrderDetails(string kind, int num, double price)
        {
            OrderService os = new OrderService();
            List<OrderDetails> odl = os.GetAllOrderDetails();
            int a = 0;
            for (a   = 0;  a< int.MaxValue; a++)
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

            this.ID = "LJF" + DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day + a.ToString();
            kindOfGoods = kind;
            numberOfGoods = num;
            this.price = price;
            totalPrice = num * price;
        }
    }
}
