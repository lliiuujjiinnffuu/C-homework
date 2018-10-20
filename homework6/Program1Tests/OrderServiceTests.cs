using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()//有参版本order
        {
            OrderService os = new OrderService();
            Order order = new Order("3333", "4444");
            os.AddOrder(order);
            Assert.IsTrue(os.orderList.Exists(a => a.customerName == "4444" && a.orderNumber == "3333"));
        }

        [TestMethod()]
        public void AddOrderTest1()//无参版本order
        {
            OrderService os = new OrderService();
            Order order = new Order();
            os.AddOrder(order);
        }

        [TestMethod()]
        public void RemoveTest()//删除第0个
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("DFDSC34234", "Jack Bree"), new Order("LLP234234", "Charie Do") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[0].CreateNewEntry("鸡腿", 300, 6);
            originList[1].CreateNewEntry("凳子", 25, 32.5);
            originList[1].CreateNewEntry("公鸡", 20, 53);
            originList[2].CreateNewEntry("鸡腿", 330, 6.6);
            originList[2].CreateNewEntry("冰棍", 560, 3.5);
            originList[2].CreateNewEntry("香蕉", 10000, 1.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            os.Remove(0);
        }
        [TestMethod()]
        public void RemoveTest1()//删除第1~3个，一共只有3个订单
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("DFDSC34234", "Jack Bree"), new Order("LLP234234", "Charie Do") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[0].CreateNewEntry("鸡腿", 300, 6);
            originList[1].CreateNewEntry("凳子", 25, 32.5);
            originList[1].CreateNewEntry("公鸡", 20, 53);
            originList[2].CreateNewEntry("鸡腿", 330, 6.6);
            originList[2].CreateNewEntry("冰棍", 560, 3.5);
            originList[2].CreateNewEntry("香蕉", 10000, 1.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            os.Remove(3);
            os.Remove(2);
            os.Remove(1);
        }
        [TestMethod()]
        public void RemoveTest2()//删除第4个，一共只有3个订单
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("DFDSC34234", "Jack Bree"), new Order("LLP234234", "Charie Do") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[0].CreateNewEntry("鸡腿", 300, 6);
            originList[1].CreateNewEntry("凳子", 25, 32.5);
            originList[1].CreateNewEntry("公鸡", 20, 53);
            originList[2].CreateNewEntry("鸡腿", 330, 6.6);
            originList[2].CreateNewEntry("冰棍", 560, 3.5);
            originList[2].CreateNewEntry("香蕉", 10000, 1.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            os.Remove(4);
        }

        [TestMethod()]
        public void FindByNameTest()//精准寻找姓名
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("可乐", 120, 3.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByName("Andy Lau");
            Assert.IsTrue(list1.Exists(a => a.customerName == "Andy Lau"));
        }

        [TestMethod()]
        public void FindByNameTest1()//模糊寻找姓名
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("可乐", 120, 3.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByName("Andy");
            Assert.IsTrue(list1.Exists(a => a.customerName == "Andy Lau") && list1.Exists(a => a.customerName == "Andy Fool"));
        }

        [TestMethod()]
        public void FindByNameTest2()//姓名寻找无结果
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("可乐", 120, 3.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByName("Andy 33");
        }
        [TestMethod()]
        public void FindByNumTest()//精准寻找订单号
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("可乐", 120, 3.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByNum("EDX541253");
            Assert.IsTrue(list1.Exists(a => a.orderNumber == "EDX541253"));
        }
        [TestMethod()]
        public void FindByNumTest1()//模糊寻找订单号
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("可乐", 120, 3.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByNum("541");
            Assert.IsTrue(list1.Exists(a => a.orderNumber == "EDX541253") && list1.Exists(a => a.orderNumber == "AJB541333"));
        }
        [TestMethod()]
        public void FindByNumTest2()//订单号寻找无结果
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("可乐", 120, 3.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByNum("333333");
        }

        [TestMethod()]
        public void FindByKindTest()//精确寻找商品种类
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("鸡腿", 120, 5.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByKind("鸡翅");
            Assert.IsTrue(list1.Exists(a => a.orderDetails.Exists(b => b.kindOfGoods == "鸡翅")));
        }
        [TestMethod()]
        public void FindByKindTest1()//模糊寻找商品种类
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("鸡腿", 120, 5.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByKind("鸡");
            Assert.IsTrue(list1.Exists(a => a.orderDetails.Exists(b => b.kindOfGoods == "鸡翅"))&& list1.Exists(a => a.orderDetails.Exists(b => b.kindOfGoods == "鸡腿")));
        }
        [TestMethod()]
        public void FindByKindTest2()//寻找商品种类无结果
        {
            OrderService os = new OrderService();
            Order[] originList = { new Order("EDX541253", "Andy Lau"), new Order("AJB541333", "Andy Fool") };
            originList[0].CreateNewEntry("可乐", 1500, 3.5);
            originList[0].CreateNewEntry("鸡翅", 552, 4.5);
            originList[1].CreateNewEntry("鸡腿", 120, 5.5);
            foreach (Order order in originList)
            {
                os.AddOrder(order);
            }
            List<Order> list1 = os.FindByKind("薯条");
        }
    }
}