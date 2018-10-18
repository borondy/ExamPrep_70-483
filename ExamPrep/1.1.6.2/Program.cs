using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<int> cBag = new ConcurrentBag<int>();
            bool addingFinished = false;

            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    cBag.Add(i);
                }
                addingFinished = true;
            }).Start();

            new Thread(()=>
            {
                while (!addingFinished)
	            {
                    Thread.Sleep(20);   
	            };
                foreach (var item in cBag)
	            {
                                Console.WriteLine(item);
	            }
            }).Start();

            Console.ReadKey();
        }
    }
}
