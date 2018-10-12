using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _1._1._2._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var parentTask = Task.Run(() =>
                {
                    var results = new string[3];

                    TaskFactory factory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                    var t1= factory.StartNew(() => results[0] = "Result from task1");
                    var t2 = factory.StartNew(() => results[1] = "Result from task2");
                    var t3 = factory.StartNew(() => results[2] = "Result from task3");

                    Task.WaitAll(t1, t2, t3); 

                    return results;
                });

            var finalTask = parentTask.ContinueWith(
                    parent =>
                    {
                        foreach (string s in parentTask.Result)
                        {
                            Console.WriteLine(s);
                        }
                    });

            finalTask.Wait();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
