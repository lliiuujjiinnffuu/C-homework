using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 23, 45, -42, 123, 4, 3, 2, 34, 3, 12, 3, 4 };
            int max = intArray[0], min = intArray[0], sum = 0;
            double average = 0;
            Console.Write("数组元素有: ");
            foreach (int i in intArray)
            {
                Console.Write(i + " ");
                max = i > max ? i : max;
                min = i < min ? i : min;
                sum += i;
            }
            Console.WriteLine();
            average = sum*1.0 / intArray.Length;
            Console.WriteLine("最大值为: " + max + "\t最小值为: " + min + "\t平均值为: " + average+"\t和为: " +sum);
        }
    }
}
