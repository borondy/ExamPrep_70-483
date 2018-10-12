using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1._2._9
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] tasks = new Task<int>[10];

            for (int i = 0; i < 10; i++)
            {
                int t=i;
                tasks[i] = Task.Run(() =>
                   {
                       Thread.Sleep(t * 1000);
                       return t;
                   });
            }

            while (tasks.Length>0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTasks = tasks[i];

                Console.WriteLine(completedTasks.Result);
                var tempTasks = tasks.ToList();
                tempTasks.RemoveAt(i);
                tasks = tempTasks.ToArray();
            }
            Console.ReadKey();
        }
    }
}
