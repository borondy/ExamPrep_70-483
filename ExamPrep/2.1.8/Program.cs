using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order(2001, 10, 10));
            orders.Add(new Order(2002, 10, 10));
            orders.Add(new Order(2004, 10, 10));
            orders.Add(new Order(2001, 11, 10));

            orders.Sort();

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
            Console.ReadKey();
        }
    }

    public class Order : IComparable<Order>
    {
        public DateTime OrderDate { get; set; }

        public Order(int year, int month, int day)
        {
            this.OrderDate = new DateTime(year, month, day);
        }

        public override string ToString()
        {
            return this.OrderDate.ToShortDateString();
        }

        public int CompareTo(Order other)
        {
            return this.OrderDate.CompareTo(other.OrderDate);
        }
    }
}
