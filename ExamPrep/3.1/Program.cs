using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!IsInputValidEmail(Console.ReadLine()))
            {
                Console.WriteLine("The given email is invalid! Please try again!");
            }

            Console.WriteLine("Thanks for the valid email! ");
            Console.ReadKey();
        }

        public static bool IsInputValidEmail(string input)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }

            return false;
        }
    }
}
