using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
                {
                    string a = await GetMicrosoftsSiteAsync();
                    Console.WriteLine(a);
                });
            while (true)
            {
                Console.WriteLine("The program is running");
                Thread.Sleep(1000);
            }
        }

        public async static Task<string> GetMicrosoftsSiteAsync()
        {
            string value;
            using (WebClient client = new WebClient())
            {
                value = await client.DownloadStringTaskAsync("http://microsoft.com");
            }
            return value;
        }
    }
}
