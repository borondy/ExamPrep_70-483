using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(new ThreadStart(CountToManagedThreadID)).Start();
            new Thread(new ThreadStart(CountToManagedThreadID)).Start();

            Console.ReadKey();
        }

        static void CountToManagedThreadID()
        {
            int currentThreadID = Thread.CurrentThread.ManagedThreadId;
            for (int i = 1; i <= currentThreadID; i++)
            {
                Console.WriteLine("Thread "+ currentThreadID+": " +i);
                Thread.Sleep(200);
            }
        }
    }
}
