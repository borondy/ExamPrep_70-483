using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._1._1._5
{
    class Program
    {
        static int counter;
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    Console.WriteLine("B: " + counter);
                    Thread.Sleep(100);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    Console.WriteLine("A: " + counter);
                    Thread.Sleep(100);
                }
            }).Start();
            Console.ReadKey();
        }

    }
}
