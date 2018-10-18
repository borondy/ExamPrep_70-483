using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _1._1._6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentDictionary<int,int> cDict = new ConcurrentDictionary<int,int>();
            bool isFinished=false;

            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    cDict.TryAdd(i, i * i);
                }
                isFinished = true;
            }).Start();

            new Thread(() =>
            {
                while (!isFinished)
                {
                    Thread.Sleep(100);
                }
                for (int i = 0; i < 100; i++)
                {
                    int v;
                    if(cDict.TryGetValue(i, out v))
                    {
                        Console.WriteLine("key: {0}, value: {1}", i, v);
                    };
                }
            }).Start();

            Console.ReadKey();


        }
    }
}
