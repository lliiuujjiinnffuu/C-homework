using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("2到100的素数有: ");
            for (int i = 2; i <=100; i++)
            {
                int factor = 2;
                while (factor<=i)
                {
                    if (i==factor)
                    {
                        Console.Write(i+" ");
                    }
                    if (i%factor!=0)
                    {
                        factor++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
