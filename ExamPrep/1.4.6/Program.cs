using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._4._6
{
    class Program
    {
        static void Main(string[] args)
        {
            House h = new House();
            Dog d = new Dog { Name = "Jessey" };

            h.OnPostmanNear += (o, s) => 
            {
                Console.WriteLine("Postman appeared at : "+ s.PostmanAppeared);
                d.Bark();
            };

            Console.WriteLine("Press enter if you see the Postman comming");
            Console.ReadKey();
            h.IsPostmanNear = true;
            Console.WriteLine("Press enter if you'd like Jessey to stop barking");
            Console.ReadKey();
            d.StopBarking();
            Console.ReadKey();

        }


    }

    public class Dog
    {
        public string Name { get; set; }
        public bool ShouldBarking { get; set; }

        public void Bark()
        {
            ShouldBarking = true;
            Task.Run(() =>
            {
                while (ShouldBarking)
                {
                    Console.WriteLine(Name + " the dog says: bark, bark at: " + DateTime.Now);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Jessey Stopped barking");
                Console.WriteLine("Jessey is a good boy :)");
            }
            );
        }

        public void StopBarking()
        {
            Console.WriteLine("Jessey! Stop barking!");
            ShouldBarking = false;
        }
    }

    public class House
    {
        public event EventHandler<PostmanNearEventArgs> OnPostmanNear;
        private bool isPostmanNear;

        public bool IsPostmanNear
        {
            get { return isPostmanNear; }
            set {
                if (OnPostmanNear!=null && value==true)
                {
                    OnPostmanNear(this,new PostmanNearEventArgs());
                }
                isPostmanNear = value; 
            }
        }

    }

    public class PostmanNearEventArgs:EventArgs
    {
        public DateTime PostmanAppeared { get; set; }
        public PostmanNearEventArgs()
        {
            PostmanAppeared = DateTime.Now;
        }
    }
}
