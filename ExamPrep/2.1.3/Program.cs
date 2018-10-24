using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product() { Price = 100 };
            

            Console.WriteLine(p.PriceWithDiscount(10));
            Console.ReadKey();
        }
    }

    public class Product
    {
        public double Price { get; set; }
    }

    static class PriceExtension
    {
        public static double PriceWithDiscount(this Product p, double percent)
        {
            return p.Price * (1 - (percent / 100));
        }
    }
}
