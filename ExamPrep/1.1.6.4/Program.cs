using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<int> cQueue = new ConcurrentQueue<int>();

            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    cQueue.Enqueue(i);
                }
            }).Start();

            new Thread(() =>
            {
                int i;
                while (cQueue.TryDequeue(out i))
                {
                    Console.WriteLine(i);
                }
            }).Start();

            Console.ReadKey();
            
        }
    }
}
