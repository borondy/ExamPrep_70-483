using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(() =>
            {
                try
                {
                while (true)
                {
                    Console.WriteLine("Thread is running");
                    Thread.Sleep(500);
                }
                }
                catch (Exception)
                {
                    Console.WriteLine("Thread Cancelled");
                }

            });
            t.Start();
            
            Console.ReadKey();
            Console.WriteLine("Cancellation requested");
            t.Abort();
            Console.ReadKey();

        }
    }
}
