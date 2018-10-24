using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._5
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }

    public class MyClass
    {
        protected internal int A { get; protected set; }
        protected int B { get; private set; }

        public MyClass()
        {

        }


    }

    public class MyDerivedClass : MyClass
    {
        public int C { get; set; }
       

        public override string ToString()
        {
            return String.Format("A= {0} B={1} C={2}", A, B, C);
        }
    }
}
