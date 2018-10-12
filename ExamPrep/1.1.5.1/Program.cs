using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Enumerable.Range(1, 100).ToArray();

            var evens = arr.Where(i => i % 2 == 0).AsParallel().ToArray();


            //query syntax
            var evens2 = (from x in arr.AsParallel() where x % 2 == 0 select x).ToArray();

            Parallel.ForEach(evens, (i)=>Console.WriteLine(i));

            Console.WriteLine("////////////////////////////////////////");

            foreach (var item in evens2)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
