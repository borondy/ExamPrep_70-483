using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var loopResult=Parallel.For(0, 100, (i, state) =>
                {
                    if (i == 75)
                        state.Stop();

                    Console.WriteLine(i);
                });

            Console.WriteLine("Lowest break iteration: " + loopResult.LowestBreakIteration);
            Console.ReadKey();
        }
    }
}
