using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var task=Task<string>.Run(() => "String returned from task");
            Console.WriteLine(task.Result);

            Console.WriteLine(Task.Run(() => "String returned from task direct in console writeline").Result);
        }
    }
}
