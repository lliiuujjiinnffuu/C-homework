using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class OrderDetails
    {
        public string kindOfGoods;
        public int numberOfGoods;
        public double price;
        public double totalPrice;
        public OrderDetails(string kind,int num,double price)
        {
            kindOfGoods = kind;
            numberOfGoods = num;
            this.price = price;
            totalPrice = num * price;
        }
        public void ShowOrderDetails()
        {
            Console.WriteLine($"商品种类:{kindOfGoods}".PadRight(12) + $"商品数量:{numberOfGoods}".PadRight(12)+$"商品单价:{price}".PadRight(12) + $"商品总价:{totalPrice}");
        }
    }
}
