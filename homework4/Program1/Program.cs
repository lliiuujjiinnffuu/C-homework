using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datetime1 = new DateTime();
            Console.WriteLine("请以 年-月-日 时:分:秒 的格式输入闹钟设定的时间(2011-8-8 10:30:30,如果没有日时分秒则默认当月1号的0:0:0)");
            bool valid = DateTime.TryParse(Console.ReadLine(), out datetime1);
            while (!valid||datetime1<=DateTime.Now)
            {
                Console.WriteLine($"输入无效字符，请输入 {DateTime.Now} 之后的时间请以 年-月-日 时:分:秒 的格式输入闹钟设定的时间(如2011-8-8 10:30:30,如果没有日时分秒则默认当月1号的0:0:0)");
                valid = DateTime.TryParse(Console.ReadLine(), out datetime1);
            }
            Console.WriteLine("闹钟将在 " + datetime1 + " 提醒您！");
            var clock = new Clock();
            clock.Clocker += ShowClock;
            clock.GoClock(datetime1);
        }
        static void ShowClock(object sender, DateTime clockTime) {
            Console.WriteLine($"\n现在时间是：{clockTime}\n叮叮叮~~叮叮叮~~\n叮叮叮~~叮叮叮~~\n叮叮叮~~叮叮叮~~\n叮叮叮~~叮叮叮~~");
        }
    }
}
