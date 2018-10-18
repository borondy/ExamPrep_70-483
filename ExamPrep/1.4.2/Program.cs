using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._2
{
    class Program
    {
        delegate Parent ParentReturner(string Name);
        static void Main(string[] args)
        {
            ParentReturner pr = CreateParent;
            pr += CreateChild;

            pr("John Doe");
            Console.ReadKey();
        }
        
        static Parent CreateParent(string name)
        {
            var p= new Parent { Name = name };
            Console.WriteLine(p);
            return p;
        }

        static Child CreateChild(string name)
        {
            var c= new Child { Name = name, Parent = new Parent { Name = name + "'s parent" } };
            Console.WriteLine(c);
            return c;
        }
        class Parent
        {
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        class Child:Parent
        {
            public Parent Parent { get; set; }

            public override string ToString()
            {
                return Name + " is a Child of " + Parent;
            }
        }
    }
}
