using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Enumerable.Range(0, 100);

            Parallel.ForEach(nums, (i) =>
            {
                Console.WriteLine(i * i);
            });
            Console.ReadKey();
        }
    }
}
