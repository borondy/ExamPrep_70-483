using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCancelled = false;

            new Thread(() =>
           {
               while (!isCancelled)
               {
                   Console.WriteLine("Not yet cancelled!");
                   Thread.Sleep(300);
               }
               Console.WriteLine("Cancelled");
           }).Start();

            Console.ReadKey();
            Console.WriteLine("Cancellation requested");
            isCancelled = true;


        }
    }
}
