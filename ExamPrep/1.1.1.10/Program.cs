using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExecutionContext.SuppressFlow();
            Thread t = new Thread(() => { Console.WriteLine("A Thread with a diferent execution context!"); ExecutionContext.SuppressFlow(); });
            t.Start();

        }
    }
}
