using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts= new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task t = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("*");
                    Thread.Sleep(1000);
                }
            }, token);


            Console.WriteLine("Press enter to stop the task");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            cts.Cancel();
            Console.WriteLine("Press enter to close the application");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
           
        }


    }
}
