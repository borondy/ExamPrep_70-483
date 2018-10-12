using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopped = StoppedLoop();
            var breaked = BreakedLoop();

            Console.WriteLine("Stopped IsCompleted: " + stopped.IsCompleted);
            Console.WriteLine("Breaked IsCompleted: " + breaked.IsCompleted);
            Console.WriteLine("Stopped LowestBreakIteration: " + stopped.LowestBreakIteration);
            Console.WriteLine("Breaked LowestBreakIteration: " + breaked.LowestBreakIteration);
            Console.ReadKey();

        }

        static ParallelLoopResult StoppedLoop()
        {
            return Parallel.For(0, 100, (i,state) =>
                {
                    if (i==75)
                    {
                        state.Stop();
                    }
                    Console.WriteLine(i);
                });
        }

        static ParallelLoopResult BreakedLoop()
        {
            return Parallel.For(0, 100, (i, state) =>
            {
                if (i == 75)
                {
                    state.Break();
                }
                Console.WriteLine(i);
            });
        }
    }
}
