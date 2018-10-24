using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Money money = new Money() { Amount = (decimal)100.3 };
            Console.WriteLine(money.Amount);
            int i = (int)money;
            Console.WriteLine(i);
            money = i;
            Console.WriteLine(money.Amount);

            Console.ReadKey();
        }
    }

    public class Money
    {
        public decimal Amount { get; set; }

        public static explicit operator int(Money m)
        {
            return (int)m.Amount;    
        }

        public static implicit operator Money(int i)
        {
            return new Money() { Amount = (decimal)i };
        }
    }
}
