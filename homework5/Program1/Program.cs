using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static OrderService orderservice = new OrderService();
        static void Main(string[] args)
        {
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
                orderservice.AddOrder(order);
            }
            Console.WriteLine("原始订单表：");
            orderservice.ShowOrder();
            Console.WriteLine("输入1添加订单，2删除订单，3修改订单，4查询订单，5打印订单表，0退出");
            int A;
            bool valid = int.TryParse(Console.ReadLine(), out A);
            while (!valid || A < 0 || A > 5)
            {
                Console.Write("输入错误，请输入0 或 1 或 2 或 3 或 4 或 5 : ");
                valid = int.TryParse(Console.ReadLine(), out A);
            }
            while (A != 0)
            {
                switch (A)
                {
                    case 1:
                        AddOrder();
                        break;
                    case 2:
                        RemoveOrder();
                        break;
                    case 3:
                        orderservice.ShowOrder();
                        Console.Write("请输入要修改的订单序号(如果要删除序列表的第一个订单即订单1就输入1：");
                        int orderNum;
                        bool valid1 = int.TryParse(Console.ReadLine(), out orderNum);
                        while (!valid1 || A > orderservice.numOfOrder)
                        {
                            Console.Write($"输入错误，请输入小于等于{orderservice.numOfOrder}整型数字:");
                            valid1 = int.TryParse(Console.ReadLine(), out orderNum);
                        }
                        Order chosenOrder = orderservice.orderList[orderNum-1];
                        AlterOrder(chosenOrder);
                        break;
                    case 4:
                        Console.WriteLine("输入1按照订单号查找，输入2按照客户姓名查找,输入3按照商品名称查找，输入4查询订单金额大于1万元的订单，0退出");
                        int A1;
                        bool valid2 = int.TryParse(Console.ReadLine(), out A1);
                        while (!valid2 || A1 < 0 || A1 > 4)
                        {
                            Console.Write("输入错误，请输入0 或 1 或 2 或 3 : ");
                            valid2 = int.TryParse(Console.ReadLine(), out A1);
                        }
                        switch (A1)
                        {
                            case 1:
                                Console.Write("\n输入要查询的订单号(可以查询出包含该字符串的订单，如 ED 可以查询出EDX541253: ");
                                string numOfOrder = Console.ReadLine();
                                Console.WriteLine("       查询结果：");
                                orderservice.FindByNum(numOfOrder);
                                break;
                            case 2:
                                Console.Write("\n输入要查询的客户姓名(可以查询出包含该字符串的订单，如 And 可以查询出Andy Lau：");
                                string name = Console.ReadLine();
                                Console.WriteLine("       查询结果：");
                                orderservice.FindByName(name);
                                break;
                            case 3:
                                Console.Write("\n输入要查询的商品名称(可以查询出包含该字符串的订单，如 香 可以查询出香蕉：");
                                string kind = Console.ReadLine();
                                Console.WriteLine("       查询结果：");
                                orderservice.FindByKind(kind);
                                break;
                            case 4:
                                Console.WriteLine("       查询结果：");
                                orderservice.FindTpMoreThan1000();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        orderservice.ShowOrder();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("输入1添加订单，2删除订单，3修改订单，4查询订单，5打印订单表，0退出");
                valid = int.TryParse(Console.ReadLine(), out A);
                while (!valid)
                {
                    Console.Write("输入错误，请输入整型数字:");
                    valid = int.TryParse(Console.ReadLine(), out A);
                }
            }
        }
        static void AddOrder()
        {
            Console.Write("输入订单号:");
            string orderNum = Console.ReadLine();
            Console.Write("输入顾客姓名:");
            string name = Console.ReadLine();
            Order newOrder = new Order(orderNum, name);
            Console.Write("输入一个新条目的商品名称:");
            string kind = Console.ReadLine();
            Console.Write("输入数量:");
            int number;
            bool valid = int.TryParse(Console.ReadLine(), out number);
            while (!valid)
            {
                Console.Write("输入错误，请输入整型数字:");
                valid = int.TryParse(Console.ReadLine(), out number);
            }
            Console.Write("输入单价:");
            double price;
            valid = double.TryParse(Console.ReadLine(), out price);
            while (!valid)
            {
                Console.Write("输入错误，请输入数字:");
                valid = double.TryParse(Console.ReadLine(), out price);
            }
            newOrder.CreateNewEntry(kind, number, price);
            AlterOrder(newOrder);
            orderservice.AddOrder(newOrder);
        }

        static void RemoveOrder()
        {
            Console.Write("当前订单表详情:");
            orderservice.ShowOrder();
            Console.Write("请输入要删除的订单序号(如果要删除序列表的第一个订单即订单1就输入1：");
            int A;
            bool valid = int.TryParse(Console.ReadLine(), out A);
            while (!valid||A>orderservice.numOfOrder)
            {
                Console.Write($"输入错误，请输入小于等于{orderservice.numOfOrder}整型数字:");
                valid = int.TryParse(Console.ReadLine(), out A);
            }
            orderservice.Remove(A);
        }

        static void AlterOrder(Order order)
        {
            int A = -1;
            while (A!=0)
            {
                Console.Write("       ");
                order.ShowOrder();
                Console.Write("输入1新建一个条目，输入2删除一个条目,输入0退出该订单的管理:");
                bool valid = int.TryParse(Console.ReadLine(), out A);
                while (!valid||A<0||A>2)
                {
                    Console.Write("输入错误，请输入0 或 1 或 2 : ");
                    valid = int.TryParse(Console.ReadLine(), out A);
                }
                switch (A)
                {
                    case 1:
                        Console.Write("输入一个新条目的商品名称:");
                        string kind = Console.ReadLine();
                        Console.Write("输入数量:");
                        int number;
                        bool valid1 = int.TryParse(Console.ReadLine(), out number);
                        while (!valid1)
                        {
                            Console.Write("输入错误，请输入整型数字:");
                            valid1 = int.TryParse(Console.ReadLine(), out number);
                        }
                        Console.Write("输入单价:");
                        double price;
                        valid1 = double.TryParse(Console.ReadLine(), out price);
                        while (!valid)
                        {
                            Console.Write("输入错误，请输入数字:");
                            valid1 = double.TryParse(Console.ReadLine(), out price);
                        }
                        order.CreateNewEntry(kind, number, price);
                        break;
                    case 2:
                        Console.Write("输入要删除的条目序号，如要删除第一个条目即条目1则输入1");
                        int number1;
                        bool valid2 = int.TryParse(Console.ReadLine(), out number1);
                        while (!valid2 || number1 > orderservice.numOfOrder)
                        {
                            Console.Write($"输入错误，请输入小于等于{orderservice.numOfOrder}整型数字:");
                            valid2 = int.TryParse(Console.ReadLine(), out number1);
                        }
                        order.RemoveEntry(number1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
