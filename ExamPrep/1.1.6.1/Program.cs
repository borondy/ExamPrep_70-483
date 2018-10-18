using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _1._1._6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<int> blockingCollection = new BlockingCollection<int>();

            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    blockingCollection.Add(i);
                }
            }).Start();

            Thread.Sleep(100); 

            new Thread(() =>
            {
                foreach (var item in blockingCollection)
                {
                    Console.WriteLine(item);
                }
            }).Start();

            Console.ReadKey();


        }
    }
}
