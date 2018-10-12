using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                for (int i = 1; i < 101; i++)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }
    }
}
