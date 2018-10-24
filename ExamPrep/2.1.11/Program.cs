using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2._1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { LastName = "Doe", FirstName = "John" };

            XmlSerializer xmlSerializer = new XmlSerializer(person.GetType());

        }
    }

    [Serializable]
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
