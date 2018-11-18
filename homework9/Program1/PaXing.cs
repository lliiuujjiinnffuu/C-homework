using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace Program1
{
    class PaXing
    {
        string current;
        private int count;
        public Hashtable urls;
        public PaXing(string current, Hashtable urls,int count)
        {
            this.urls = urls;
            urls[current] = true;
            this.count = count;
            this.current = current;
        }
        public void paxing()
        {
            Console.WriteLine("爬行" + current + "页面!");
            //Console.WriteLine("当前线程："+Thread.CurrentThread.ManagedThreadId);
            string html = Download(current);
            Parse(html);
        }
        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string filename = count.ToString();
                File.WriteAllText(filename, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                if (strRef.Length == 0)
                {
                    continue;
                }
                if (urls[strRef] == null)
                {
                    urls[strRef] = false;
                }
            }
        }
    }
}
