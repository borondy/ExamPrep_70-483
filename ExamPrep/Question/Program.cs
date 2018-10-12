
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> original = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                original.Add(i);
            }

            var odd = original.Where(i => i % 2 == 0);

            foreach (var i in odd)
            {
                Console.WriteLine(i);
            }

            original.Add(10);
            original.Add(11);

            Console.WriteLine("/////////////////");

            foreach (var i in odd)
            {
                Console.WriteLine(i);
            }
        }
    }
}
