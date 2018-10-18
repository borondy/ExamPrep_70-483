using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> Calculate;
            Calculate = Sum;
            Console.WriteLine(Calculate(1,2));
            Calculate += (int a, int b) => a + b;
            Console.WriteLine(Calculate(1,3));
            Calculate += (a, b) => a + b;
            Console.WriteLine(Calculate(1,4));
            Console.ReadKey();
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
