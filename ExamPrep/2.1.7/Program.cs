using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            d.Execute();

            Base b = d;
            d.Execute();

            ((Base)d).Execute();

            Console.ReadKey();
        }
    }

    public class Base
    {
        public virtual void Execute()
        {
            Console.WriteLine("Called from Base");
        }
    }

    public class Derived:Base
    {
        public override void Execute()
        {
            Console.WriteLine("Called from Derived");
        }
    }
}
