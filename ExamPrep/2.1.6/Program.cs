using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            d.Execute();
            ((Base)d).Execute();

            Base b = d;
            b.Execute();
            d.Execute();

            Console.ReadKey();
        }
    }

    public class Base
    {
        public void Execute()
        {
            Console.WriteLine("Execute called from Base");
        }
    }

    public class Derived:Base
    {
        public new void Execute()
        {
            Console.WriteLine("Execute called from the Derived");
        }
    }
}
