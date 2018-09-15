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
            List<int> primeArray = new List<int>(99);
            for (int i = 2; i < 100; i++)
            {
                primeArray.Add(i);
            }
            for (int i = 2; i <=50; i++)
            {
                for (int j = 0; j < primeArray.Count; j++)
                {
                    if (primeArray[j]%i==0&&primeArray[j]!=i)
                    {
                        primeArray.RemoveAt(j);
                    }
                }
            }
            Console.Write("2到100的素数有: ");
            foreach (int p in primeArray)
            {
                Console.Write(p+" ");
            }
            Console.WriteLine();
        }
    }
}
