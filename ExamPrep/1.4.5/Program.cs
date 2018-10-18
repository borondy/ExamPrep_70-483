using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int, int> action = (a, b) => Console.WriteLine(a+b);
            action(1, 2);
            Console.ReadKey();
        }
    }
}
