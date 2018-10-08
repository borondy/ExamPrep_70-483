using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(300);
                }
            });
            t.IsBackground = true;
            t.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
