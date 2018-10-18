using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._1
{
    class Program
    {
        public delegate void Calculate(int a, int b);
        static void Main(string[] args)
        {
            Calculate c;
            c = Sum;
            c += Multiply;

            c(10, 22);
            Console.ReadKey();
        }
        public static void Sum(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public static void Multiply(int a, int b)
        {
            Console.WriteLine(a*b);
        }
    }
}
