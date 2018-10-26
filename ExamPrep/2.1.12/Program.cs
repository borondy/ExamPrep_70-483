using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._12
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 10;

            var methodInfoOfa = a.GetType().GetMethods();

            foreach (var method in methodInfoOfa)
            {
                if (method.Name=="CompareTo")
                {
                    Console.WriteLine(method.Invoke(a, new object[] { b }));
                }
            }

            Console.ReadKey();

        }
    }
}
