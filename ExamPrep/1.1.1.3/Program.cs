using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1._1._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() => CountTo(10)).Start();
        }
        static void CountTo(int limit)
        {
            for (int i = 1; i <= limit; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
