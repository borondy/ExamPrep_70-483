using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => "Value Needs to be written to Console").ContinueWith((t) =>
            {
                Console.WriteLine(t.Result);
            });
            Console.ReadKey();

        }
    }
}
