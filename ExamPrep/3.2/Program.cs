using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _3._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person= new Person()
                        { FirstName = "John"
                         ,LastName = "Doe"
                         ,DateOfBirth = new DateTime(1993, 10, 10) };

            var serializer = new JavaScriptSerializer();

            var serializedPerson = serializer.Serialize(person);

            Console.WriteLine(serializedPerson);

            Person deserializedPerson = (Person)serializer.Deserialize(serializedPerson, typeof(Person));

            Console.WriteLine(deserializedPerson.ToString());

            Console.ReadKey();

        }


    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static Person GetSamplePerson()
        {
            return new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1993, 10, 10)
            };
        }

        public override string ToString()
        {
            return this.FirstName + " "
                             + this.LastName + " "
                             + this.DateOfBirth.ToShortDateString();
        }
    }
}
