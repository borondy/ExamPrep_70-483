using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._1._1._6
{
    class Program
    {
        [ThreadStatic]
        static int counter = 0;
        static void Main(string[] args)
        {
            new Thread(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        counter++;
                        Console.WriteLine(counter);
                    }
                }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    Console.WriteLine(counter);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
