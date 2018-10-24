using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Days d = Days.WeekDays;
            Console.WriteLine("Days.WeekDays= " + d.ToString());

            Days weekDays = Days.Monday 
                            | Days.Tuesday 
                            | Days.Thursday
                            | Days.Wednesday 
                            | Days.Friday;

            Console.WriteLine("Week days with | 'concatenated'= " + weekDays);

            Console.WriteLine("Is Days.WeekDays==Days.Monday|Days.Tuesday....| Days.Friday? "
                            + (weekDays == Days.WeekDays).ToString());

            Console.ReadKey();
        }

        [Flags]
        enum Days
        {
            Sunday=1,
            Monday=2,
            Tuesday=4,
            Thursday=8,
            Wednesday=16,
            Friday=32,
            Saturday=64,
            WeekDays=62
        }
    }
}
