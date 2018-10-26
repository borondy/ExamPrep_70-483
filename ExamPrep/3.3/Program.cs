using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using _3._2;

namespace _3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.GetSamplePerson();

            var serializer = new XmlSerializer(typeof(Person));

            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, person);

                Console.WriteLine(sw.ToString());

                using (StringReader sr = new StringReader(sw.ToString()))
                {
                    Person deserializedPerson = (Person)serializer.Deserialize(sr);
                    Console.WriteLine(deserializedPerson);
                }
            }

            Console.ReadKey();
        }
    }
}
