using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._7
{
    //Create a class with an OnChange event and a Raise method(which raise it). 
    //Create an instance of the class. Subscribe to the event with multiple event handlers.
    //    Throw exception from one of the handlers.Do the class capable to execute all of the 
    //    subscriptions however one of them throws an exception.If it happens write out the 
    //    count of the exceptions to the Console(h1, h2=>exception, h3 count of exceptions = 1) (page 90.)

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.OnChange += P_OnChange;
            p.OnChange += P_OnChange1;
            p.OnChange += P_OnChange2;

            try
            {
                p.Change();
            }
            catch (AggregateException e)
            {

                Console.WriteLine(e.InnerExceptions.Count);
            }

            Console.ReadKey();
        }

        private static void P_OnChange2(object sender, EventArgs e)
        {
            Console.WriteLine("Handler 3");
        }

        private static void P_OnChange1(object sender, EventArgs e)
        {
            throw new Exception();
        }

        private static void P_OnChange(object sender, EventArgs e)
        {
            Console.WriteLine("Handler 1");
        }

        class Person
        {
            public event EventHandler<EventArgs> OnChange = delegate { };

            public void Change()
            {
               var exceptions = new List<Exception>();

                foreach (var del in OnChange.GetInvocationList())
                {
                    try
                    {
                        del.DynamicInvoke(this, EventArgs.Empty);
                    }
                    catch (Exception e)
                    {

                        exceptions.Add(e);
                    }

                }

                if (exceptions.Any())
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
