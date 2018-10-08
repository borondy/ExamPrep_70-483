using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._1._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(CountToTen));
            Thread t2 = new Thread(new ThreadStart(CountToTen));

            t1.Start();
            t2.Start();

        }

        static void CountToTen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
    }
}
