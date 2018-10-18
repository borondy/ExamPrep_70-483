using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._3
{
    class Program
    {
        delegate void WriteToConsole(Child child);
        static void Main(string[] args)
        {
            WriteToConsole wtc = DescribeChild;
            wtc += DescribeParent;

            wtc(new Child { Name = "Jane Doe", Parent = new Parent { Name = "John Doe" } });

            Console.ReadKey();
            
        }

        static void DescribeParent(Parent p)
        {
            Console.WriteLine(p.Name);
        }

        static void DescribeChild(Child c)
        {
            Console.WriteLine(c);
        }
        class Parent
        {
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        class Child : Parent
        {
            public Parent Parent { get; set; }

            public override string ToString()
            {
                return Name + " is a Child of " + Parent;
            }
        }
    }
}
