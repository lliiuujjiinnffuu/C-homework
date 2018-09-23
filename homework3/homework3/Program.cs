using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎来到图形工厂，请输入你想要创建的图形:\r\nTriangle代表三角形，Circle代表圆形，\r\nSquare代表正方形，Rectangle代表长方形\r\n输入0可以退出程序");
            String graphName = null;
            graphName = Console.ReadLine();
            GraphFactory factory = new GraphFactory();
            Graph graph = null;
            while (String.Compare(graphName, "0") != 0)
            {
                if (String.Compare(graphName,"Triangle")==0|| String.Compare(graphName, "Circle") == 0 || String.Compare(graphName, "Rectangle") == 0 || String.Compare(graphName, "Square") == 0)
                {
                    graph = factory.createGraph(graphName);
                    double a = graph.getArea();
                    Console.WriteLine("面积为： "+graph.getArea());
                    Console.WriteLine("\r\n请输入你想要创建的图形:(Triangle，Circle，Square，Rectangle,0退出)");
                    graphName = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("输入无效字符，请重新输入有效字符：(Triangle，Circle，Square，Rectangle,0退出)");
                    graphName = Console.ReadLine();
                }
            }
        }
    }
    class Graph
    {
        public virtual double getArea()
        {
            double Area = 0;
            return Area;
        }
    }
    class GraphFactory
    {
        public Graph createGraph(string operate)
        {
            Graph graph = null;
            switch (operate)
            {
                case "Triangle":
                    graph = new Triangle();
                    break;
                case "Circle":
                    graph = new Circle();
                    break;
                case "Square":
                    graph = new Square();
                    break;
                case "Rectangle":
                    graph = new Rectangle();
                    break;
            }
            return graph;
        }
        class Triangle : Graph
        {
            private double baseborder = 0, height = 0;
            public Triangle()
            {
                Console.WriteLine("请输入三角形的底边长度");
                bool valid = false;
                valid = double.TryParse(Console.ReadLine(), out baseborder);
                while (!valid||baseborder <=0)
                {
                    Console.WriteLine("输入无效字符，请输入大于0的数字！");
                    valid = double.TryParse(Console.ReadLine(), out baseborder);
                }
                Console.WriteLine("请输入三角形的高度");
                valid = false;
                valid = double.TryParse(Console.ReadLine(), out height);
                while (!valid || height <= 0)
                {
                    Console.WriteLine("输入无效字符，请输入大于0的数字！");
                    valid = double.TryParse(Console.ReadLine(), out height);
                }
            }
            public override double  getArea()
            {          
                return (height * baseborder / 2);
            }
        }
        class Circle : Graph
        {
            private double radius = 0;
            public Circle()
            {
                Console.WriteLine("请输入圆形的半径");
                bool valid = false;
                valid = double.TryParse(Console.ReadLine(), out radius);
                while (!valid || radius <= 0)
                {
                    Console.WriteLine("输入无效字符，请输入大于0的数字！");
                    valid = double.TryParse(Console.ReadLine(), out radius);
                }
            }
            public override double getArea()
            {
                return (radius * radius * 3.141592654);
            }
        }
        class Square : Graph
        {
            private double border = 0;
            public Square()
            {
                Console.WriteLine("请输入正方形的边长");
                bool valid = false;
                valid = double.TryParse(Console.ReadLine(), out border);
                while (!valid ||border <= 0)
                {
                    Console.WriteLine("输入无效字符，请输入大于0的数字！");
                    valid = double.TryParse(Console.ReadLine(), out border);
                }
            }
            public override double getArea()
            {
                return (border * border);
            }
        }
        class Rectangle : Graph
        {
            private double length = 0, width = 0;
            public Rectangle()
            {
                Console.WriteLine("请输入长方形的长度");
                bool valid = false;
                valid = double.TryParse(Console.ReadLine(), out length);
                while (!valid || length <= 0)
                {
                    Console.WriteLine("输入无效字符，请输入大于0的数字！");
                    valid = double.TryParse(Console.ReadLine(), out length);
                }
                Console.WriteLine("请输入长方形的宽度");
                valid = false;
                valid = double.TryParse(Console.ReadLine(), out width);
                while (!valid || width <= 0)
                {
                    Console.WriteLine("输入无效字符，请输入大于0的数字！");
                    valid = double.TryParse(Console.ReadLine(), out width);
                }
            }
            public override double getArea()
            {
                return (length * width);
            }
        }
    }
}