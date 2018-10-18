using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            t.Wait();
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}
