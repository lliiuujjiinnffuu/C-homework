using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个整型数字，求其所有素数因子:");
            int num, factor = 2;
            bool valid = false;
            valid = int.TryParse(Console.ReadLine(), out num);
            while (!valid)
            {
                Console.WriteLine("输入无效字符，请输入整型数字！");
                valid = int.TryParse(Console.ReadLine(), out num);
            }
            Console.Write(num + " = ");
            while (factor <= num)
            {
                while (factor <= num && num % factor != 0)
                {
                    factor++;
                }
                num /= factor;
                Console.Write(factor);
                if(num != 1)
                {
                    Console.Write(" * ");
                }
                factor = 2;
            }
            Console.WriteLine();
        }
    }
}
