using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _1._1._2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var parent = Task.Run(() =>
            {
                var results=new int[3];
                Task<int> t1 = Task.Run(() => results[0] = 1);
                Task<int> t2 = Task.Run(() => results[1] = 2);
                Task<int> t3 = Task.Run(() => results[2] = 3);
                
                Task.WaitAll(t1, t2, t3);
                return results;
            });

            var finalTask=parent.ContinueWith(
                parentTask =>
                {
                    foreach (int s in parentTask.Result)
                    {
                        Console.WriteLine(s);
                    }
                }
                );
            finalTask.Wait();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();

        }
    }
}
