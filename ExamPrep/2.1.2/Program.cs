using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point() { X = 1, Y = 2 };
            Point p2 = new Point(1, 2);

            Console.WriteLine(p==p2);
            Console.ReadKey();
        }

        struct Point
        {
            public int X;
            public int Y;

            //public Point()  // Can't have parameterless constructor
            //{

            //}

            //public Point(int x) // Musst assign all of the fields
            //{
            //    X = x;
            //}

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                if (obj.GetType()!=this.GetType())
                {
                    return false;
                }
                var other = (Point)obj;
                return this.X == other.X && this.Y == other.Y;
            }

            public static bool operator == (Point a, Point b)
            {
                return a.Equals(b);
            }

            public static bool operator != (Point a, Point b)
            {
                return !a.Equals(b);
            }

            
        }
    }
}
