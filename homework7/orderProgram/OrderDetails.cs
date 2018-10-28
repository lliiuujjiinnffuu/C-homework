using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//订单的输入操作
namespace Orders
{
    [Serializable]
    public class OrderDetails
    {
        public string kindOfGoods { set; get; }
        public int numberOfGoods { set; get; }
        public double price { set; get; }
        public double totalPrice { set; get; }
        public OrderDetails() { }
        public OrderDetails(string kind, int num, double price)
        {
            kindOfGoods = kind;
            numberOfGoods = num;
            this.price = price;
            totalPrice = num * price;
        }
    }
}
