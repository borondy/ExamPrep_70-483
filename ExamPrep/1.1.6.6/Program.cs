using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            //Thread t=new Thread(() => 
            //    {
            //        for (int i = 0; i < 1000000; i++)
            //        {
            //            n++;
            //        }
            //    }
            //    );
            //t.Start();

            Task t2 = Task.Run(() =>
            {
                 for (int i = 0; i < 1000000; i++)
                {
                    n++;
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }

            //t.Join();
            t2.Wait(); 
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}
