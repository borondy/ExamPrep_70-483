using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((s) => {
                    Console.WriteLine("Requested from ThreadPool"); });

            Console.ReadKey();
           
        }
    }
}
