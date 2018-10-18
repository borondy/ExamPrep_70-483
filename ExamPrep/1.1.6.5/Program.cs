using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._6._5
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> cStack = new ConcurrentStack<int>();

            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    cStack.Push(i);
                }
            }).Start();

            Thread.Sleep(10);

            new Thread(() =>
            {
                int i;
                while (cStack.TryPop(out i))
                {
                    Console.WriteLine(i);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
