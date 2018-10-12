using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Enumerable.Range(1, 100).ToArray();

            arr.AsParallel().Where(n => n % 2 == 0).ForAll((i)=>Console.WriteLine(i));

            Console.ReadKey();
        }
    }
}
