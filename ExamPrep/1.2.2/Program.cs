using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            object _lock = new object();
            int n = 0;

            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                    {
                        n++;
                    }
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    n--;
                }
            }

            t.Wait();
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}
