using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks= new Task[5];
            for (int i = 0; i < 5; i++)
            {
                int t = i;
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine(t * t);
                });
            }
            Task.WaitAll(tasks);
            Console.WriteLine("The tasks has been completed");
            Console.ReadKey();

        }
    }
}
