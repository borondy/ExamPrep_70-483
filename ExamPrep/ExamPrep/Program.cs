﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(CountToTen).Start();
            CountToTen();
        }

        private static void CountToTen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
