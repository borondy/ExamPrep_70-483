using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var loopResult=Parallel.For(0, 100, (i,s) =>
                {
                    if (i==75)
                    {
                        s.Break();
                    }
                    Console.WriteLine(i);
                });
            Console.WriteLine("Lowest break iteration: "+loopResult.LowestBreakIteration);
            Console.ReadKey();
        }
    }
}
