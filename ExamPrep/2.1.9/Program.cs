using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person> {
                    new Person("John","Doe"),
                    new Person("Jake","Doe"),
                    new Person("Jean","Doe"),
                    new Person("Jim","Doe")
                };

            People people = new People(peopleList);

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            Console.ReadKey();
        }
    }

    public class People:IEnumerable<Person>
    {
        Person[] people;

        public People(List<Person> peopleList)
        {
            people = peopleList.ToArray();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            foreach (var item in people)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
