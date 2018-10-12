using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
                {
                    throw new NotImplementedException();
                })
                .ContinueWith((t) =>
                {
                    Console.WriteLine("Exception throwed by parent thread");
                }, TaskContinuationOptions.OnlyOnFaulted);

            Task.Run(() =>
                {throw new NotImplementedException();})
                .ContinueWith((t) =>
                {
                    Console.WriteLine("This should never be written to the console");
                }
                ,   TaskContinuationOptions.NotOnFaulted);

            Console.ReadKey();
        }
    }
}
