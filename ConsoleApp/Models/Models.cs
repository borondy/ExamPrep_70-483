using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp.Models
{

    public class ImageOfDay
    {
        public string date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }
    public class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int LengthInSeconds { get; set; }
        public MusicTrack()
        {
            
        }
    }

    

    public class ConsoleTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            System.Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }

    public class DisposableObject : IDisposable
    {
        //flag to indicate when the object has been disposed
        bool disposed=false;
        public void Dispose()
        {
            //call dispose and thell it that it is being called from the Dispose 
            //call
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            //give up if already disposed
            if(disposed)
                return;
            if(disposing)
            {
                //free any managed objects here
            }

            //free any unmanaged objects here
        }

        ~DisposableObject()
        {
            //Dispose only of unmanaged objects
            Dispose(false);
        }
    }

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Enum)]
    public class ProgrammerAttribute:Attribute
    {
        private string programmerName;
        public ProgrammerAttribute(string programmer)
        {
            programmerName=programmer;
        }
        public string Programmer{get=>programmerName;}

        // [Programmer(programmer:"Hunor")]
        // public static void InvalidVoid()=>throw new NotImplementedException();
    }
    [Programmer(programmer:"Hunor")]
    public enum DaysOfWeek
    {
        Monday,
        Tuesday
    }

    [Serializable]
    [Programmer(programmer:"Hunor")]
    public class ClassWithAttribute
    {

    }

    public class EasyerEnumeratorThing : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < limit; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int limit;
        public EasyerEnumeratorThing(int limit)
        {
            this.limit=limit;
        }
    }

    public class EnumeratorThing : IEnumerator<int>,IEnumerable
    {
        int count;
        int limit;
        public int Current=>count;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++count==limit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            count=0;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public EnumeratorThing(int limit)
        {
            count=0;
            this.limit=limit;
        }
    }

    public class MathResult : IComparable, IComparable<int>
    {
        public int Result { get; set; }

        public MathResult(int res)
        {
            Result=res;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            MathResult other= (MathResult)obj;
            return this.Result.CompareTo(other.Result);
        }

        public static List<MathResult> GetResults()
        {
            return new MathResult[]
            {
                new MathResult(11),
                new MathResult(21),
                new MathResult(425),
                new MathResult(133),
                new MathResult(8)
            }.ToList();
        }

        public int CompareTo(int other)
        {
            return this.Result.CompareTo(other);
        }
    }

    public class Parent
    {
        private string firstName;
        protected string lastName;
        public string Name { get; set; }
        private void PrivateVoid(){System.Console.WriteLine("this is private");}
        protected virtual void ProtectedVoid(){System.Console.WriteLine("this is protected");}
    }

    public class Child:Parent
    {
        public Child()
        {
            this.ProtectedVoid();
            base.ProtectedVoid();
        }

        public void PubliChildVoid()=>System.Console.WriteLine("this is a public child void");

        protected override void ProtectedVoid()
        { System.Console.WriteLine("this is an overrided protected void");}
        public void ProtectedVoidWrapper()=>ProtectedVoid();
    }

    public class Miles
    {
        public double Distance { get; set; }
        public static implicit operator Kilometers(Miles m)
        {
            return new Kilometers { Distance = m.Distance * 1.609 };
        }
        public static explicit operator int(Miles m)
        {
            return (int)(m.Distance + 0.5);
        }
    }

    public class Kilometers
    {
        public double Distance { get; set; }
        public static implicit operator Miles(Kilometers k)
        {
            return new Miles { Distance = (k.Distance / 1.609) };
        }
    }

    public class IntArrayWrapper
    {
        private int[] array = new int[100];

        public int this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }
    }

    public struct Alien
    {
        public int X;
        public int Y;
        public int Lives;

        public Alien(int x, int y)
        {
            X = x;
            Y = y;
            Lives = 3;
        }
        public override string ToString() =>
         $"The alien is on the following coordinates: X={this.X}; " +
         $"Y={this.Y} and has {this.Lives} lives";
    }
    public struct Astruct
    {
        public int Data { get; set; }
    }
    public class Aclass
    {
        public int Data { get; set; }
    }
    public class Alarm
    {
        public event EventHandler<AlarmRaisedEventArgs> OnAlarmRAised;

        public void RaiseAlarm()
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (Delegate handler in OnAlarmRAised.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, new AlarmRaisedEventArgs());
                }
                catch (System.Exception e)
                {
                    exceptions.Add(e.InnerException);
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }

    public class CalcException : Exception
    {
        public CalcExceptionType CalcExceptionType { get; set; }
        public CalcException(string message, CalcExceptionType calcExceptionType) : base(message)
        {
            CalcExceptionType = calcExceptionType;
        }
    }

    public enum CalcExceptionType
    {
        DivideByZero,
        InvalidNumber
    }

    public class AlarmRaisedEventArgs : EventArgs
    {
        public DateTime EventRaisedAt { get; set; }
        public AlarmRaisedEventArgs() { EventRaisedAt = DateTime.UtcNow; }
    }

    public class FullName
    {
        public string Value { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public FullName FullName { get; set; }



        public Person(string name, string city)
        {
            Name = name;
            City = city;
        }

        public Person(string fullName)
        {
            this.FullName = new FullName { Value = fullName };
        }

        public static List<Person> GetPeopleWithFullNamesList() =>
        new List<Person>{
            new Person("Aladar"),
            new Person("Bence"),
            new Person("Reka"),
            new Person("Zsolt"),
            new Person("Kriszti"),
            new Person("Sandor"),
            new Person("Zsolt"),
            new Person("Zsombor"),
            new Person("Aladar"),
            new Person("Bence"),
            new Person("Reka"),
            new Person("Zsolt"),
            new Person("Kriszti"),
            new Person("Sandor"),
            new Person("Zsolt"),
            new Person("Zsombor"),
            new Person("Aladar"),
            new Person("Bence"),
            new Person("Reka"),
            new Person("Zsolt"),
            new Person("Kriszti"),
            new Person("Sandor"),
            new Person("Zsolt"),
            new Person("Zsombor")
        };


        public static List<Person> GetPersonList() =>
        new List<Person>{
            new Person("Aladar","Aba"),
            new Person("Bence","Aba"),
            new Person("Reka","Aba"),
            new Person("Zsolt","Szeged"),
            new Person("Kriszti","Lipot"),
            new Person("Sandor","Buda"),
            new Person("Zsolt","Buda"),
            new Person("Zsombor","Buda"),
            new Person("Aladar","Aba"),
            new Person("Bence","Aba"),
            new Person("Reka","Aba"),
            new Person("Zsolt","Szeged"),
            new Person("Kriszti","Lipot"),
            new Person("Sandor","Buda"),
            new Person("Zsolt","Buda"),
            new Person("Zsombor","Buda"),
            new Person("Aladar","Aba"),
            new Person("Bence","Aba"),
            new Person("Reka","Aba"),
            new Person("Zsolt","Szeged"),
            new Person("Kriszti","Lipot"),
            new Person("Sandor","Buda"),
            new Person("Zsolt","Buda"),
            new Person("Zsombor","Buda")
        };

    }
}