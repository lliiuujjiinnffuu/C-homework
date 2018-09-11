using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入第一个数字:");
            double a, b;
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("输入第二个数字:");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("{0} * {1}  = " + (a * b), a, b);
        }
    }
}