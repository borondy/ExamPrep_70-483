using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(1,101,(i)=>Console.WriteLine(i));
            Console.ReadKey();
        }

    }
}
