using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._2._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int t=i;
                tasks[i] = Task.Run(() => Console.WriteLine(t * t));
            }
            int firstCompletedTask=Task.WaitAny(tasks);
            Console.WriteLine("The first completed task had the following index: "+firstCompletedTask);
            Console.ReadKey();
        }
    }
}
