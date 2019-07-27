#define TERSE
#define VERBOSE
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsoleApp.Models;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static long totalAmount = 0;
        delegate int IntOperation(int a, int b);
        static void Main(string[] args)
        {
            // ParallelInvoke();
            // ParallelForEach();
            // ParallelFor();
            // ManageParallelForEach();
            // PLINQDemo();
            // CreateTasks();
            // TaskWaitAll();
            // TaskContinuation();
            // ChildTaskDemo();
            // ThreadCreation();
            // ThreadAbortDemo();
            // ThreadAbortWithFlagDemo();
            // ThreadJoin();
            // ThreadLocalDemo();
            // ThreadFromThreadPool();
            // BlockingCollectionAsWrapper();
            // TaskCancellationDemo();
            // IncrementFromMultipleTask();
            // IncrementFromMultipleTaskWrongly();
            // WriteFrom1to10();
            // ForEachFullNamePeople();
            // OperatorTest();
            // AlarmWithActionDelegate();
            // DelegateDemo();
            // AggregateExceptionTest();
            // StructTest();
            // ClassTest();
            // AlienTest();
            // CastingTest();
            // MathResultOrderTester();
            // EnumeratorTest();
            // EasyerEnumeratorThingTest();
            // AttributeTests();
            // CallMethodWithReflection();
            // StringWriterTest();
            // ConsoleStringFormaters();
            // SerializeXML();
            // EncryptionDemo();
            // AssemblyReflection();
            // DebugAssert();
            // TraceListenerTest();  
            // GetContentOfWebPage();
            // Task.Run(()=>GetContentOfWebPage()).Wait();
            // string text=Task.Run(async()=>await GetWebPageContentAsync()).Result;
            // System.Console.WriteLine(text);
            // Task.Run(async ()=>{
            //     var result=await GetWebPageContentWithHTTPClientAsync();
            //     System.Console.WriteLine(result);
            // }).Wait();
            // System.Console.WriteLine(GetImageOfDay().Result.url);
            // ArrayCountTester();
            // HierarchyTest();
            // LinQQuerySyntax();
            BinarySerializingDemo();
        }

        private static void BinarySerializingDemo()
        {
            BinaryFormatter formatter= new BinaryFormatter();
            var artists=Artist.GetListOfArtists();
            using ( FileStream fs = new FileStream("data.bin",FileMode.OpenOrCreate,FileAccess.Write) )
            {
                formatter.Serialize(fs,artists);
            }

            List<Artist> artistList;
            using (FileStream fs= new FileStream("data.bin",FileMode.Open,FileAccess.Read))
            {
                artistList=(List<Artist>)formatter.Deserialize(fs);
            }
            System.Console.WriteLine(artistList.Count);
        }

        private static void LinQQuerySyntax()
        {
            List<MusicTrack> tracks=MusicTrack.GetListOfMusicTracks();
            List<Artist> artists=Artist.GetListOfArtists();

            var listOfTracksAndMusics=
                from track in tracks 
                join artist in artists on track.ArtistID equals artist.ID
                select new 
                {ArtistName= artist.Name, Title=track.Title, Length=track.LengthInSeconds};
            
            var listOfTracksAndMusicsWithMethodSyntax=
                tracks.Join(
                        artists,
                        t=>t.ArtistID,
                        a=>a.ID,
                (t,a)=> new{
                    ArtistName= a.Name, Title=t.Title, Length=t.LengthInSeconds
                });

            var artistsOnTracksJoin=artists.Join(tracks,a=>a.ID, t=>t.ArtistID,(a,t)=>new {
                Artist=a.Name, Title=t.Title, Length=t.LengthInSeconds
            });

            var artistsOnTracksJoinWithQuery=from artist in artists
                                             join track in tracks 
                                             on artist.ID equals track.ArtistID
                                             select new {
                                                        Artist=artist.Name,
                                                        Title=track.Title,
                                                        Length=track.LengthInSeconds
                                                        };
            
            foreach (var track in listOfTracksAndMusics)
            {
                System.Console.WriteLine($"Artist:{track.ArtistName}; Title: {track.Title}({track.Length})");
            }
            System.Console.WriteLine("//////////////////////////////////////////////////");
            foreach (var track in listOfTracksAndMusicsWithMethodSyntax)
            {
                System.Console.WriteLine($"Artist:{track.ArtistName}; Title: {track.Title}({track.Length})");
            }
        }

        private static void HierarchyTest()
        {
            ParentClass parentClass=new ParentClass();
            ChildClass child=new ChildClass();
            System.Console.WriteLine("ParentClass says: ");
            parentClass.PublicVoid();
            parentClass.VoidToOverrideByChild();
            System.Console.WriteLine("ChildClass says: ");
            child.PublicVoid();
            child.VoidToOverrideByChild();
            parentClass=child;
            System.Console.WriteLine("Child as Parent says:");
            parentClass.PublicVoid();
            parentClass.VoidToOverrideByChild();
        }

        private static void ArrayCountTester()
        {
            int [,] ints= new int[3,4];
            int [][] ints2= new int[3][];

            ints2[0]=new int[]{1,2,3};
            ints2[1]=new int[4]{1,2,3,4};
            ints2[2]=new int[4]{1,2,3,4};
            
            System.Console.WriteLine($"The length of int[3,4]= {ints.Length.ToString()}");
            System.Console.WriteLine($"The length of int[3][]= {ints2.Length.ToString()}");
            


        }

        private static async Task<ImageOfDay> GetImageOfDay(string imageURL="https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date=2019-07-26")
        {
            string NASAJson=await Task<string>.Run(async ()=>{
                HttpClient client=new HttpClient();
                return await client.GetStringAsync(imageURL);
            });

            ImageOfDay result= JsonConvert.DeserializeObject<ImageOfDay>(NASAJson);

            return result;
        }
        private static async Task<string> GetWebPageContentWithHTTPClientAsync()
        {
            HttpClient client= new HttpClient();
            return await client.GetStringAsync(new Uri("https://microsoft.com"));
        }

        private static async Task<string> GetWebPageContentAsync()
        {
            WebClient client= new WebClient();
            return await client.DownloadStringTaskAsync(new Uri("http://microsoft.com"));
        }

        private static void GetContentOfWebPageWithWebClient()
        {
            WebClient client= new WebClient();
            client.DownloadStringAsync(new Uri("https://microsoft.com"));
            client.DownloadStringCompleted+=(s,o)=>{
                System.Console.WriteLine(o.Result);
            };
            
        }

        private static void GetContentOfWebPage()
        {
            WebRequest webRequest = WebRequest.Create("http://microsoft.com");
            WebResponse webResponse= webRequest.GetResponse();

            using (StreamReader responseReader= new StreamReader(webResponse.GetResponseStream()))
            {
                string siteText=responseReader.ReadToEnd();
                System.Console.Write(siteText);
            }
        }

        private static void TraceListenerTest()
        {
            TraceListener consoleListener=new ConsoleTraceListener();
            Trace.Listeners.Add(consoleListener);
            Trace.TraceInformation("This is an information message");
            Trace.TraceWarning("This is a warning message");
            Trace.TraceError("This is an error message");
        }

        private static void DebugAssert()
        {
            string name="";
            Debug.Assert(!string.IsNullOrEmpty(name));

            System.Console.WriteLine("Continued");

        }
        private static void AssemblyReflection()
        {
            var assembly=Assembly.GetExecutingAssembly();
            System.Console.WriteLine(assembly.FullName);
        }
        private static void EncryptionDemo()
        {
            string plainText="This is my secret";
            byte[] secretText;
            byte[] key;
            byte[] initializeVector;

            using (Aes aes= Aes.Create())
            {
                key=aes.Key;
                initializeVector=aes.IV;

                ICryptoTransform encryptor=aes.CreateEncryptor();
                
                using (MemoryStream memoryStream=new MemoryStream() )
                {
                    using (CryptoStream cryptoStream =
                     new CryptoStream(memoryStream,encryptor,CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt= new StreamWriter(cryptoStream))
                        {
                            swEncrypt.Write(plainText);
                        }
                        secretText=memoryStream.ToArray();
                    }
                }

            }

            DumpBytes("Key: ", key);
            DumpBytes("Initialization Vector: ", initializeVector);
            DumpBytes("Encrypted: ", secretText);

            string decryptedText;
            using (Aes aes = Aes.Create())
            {
                aes.Key=key;
                aes.IV=initializeVector;

                ICryptoTransform decryptor= aes.CreateDecryptor();

                using (MemoryStream decryptStream = new MemoryStream(secretText))   
                {
                    using (CryptoStream decryptCryptoStream= new CryptoStream(decryptStream,decryptor,CryptoStreamMode.Read))
                    {
                        using (StreamReader sr= new StreamReader(decryptCryptoStream))
                        {
                            decryptedText=sr.ReadToEnd();
                        }
                    }
                }
            }

            System.Console.WriteLine($"Decrypted text: {decryptedText}");

        }

        public static void DumpBytes(string title, byte[] bytes)
        {
                System.Console.WriteLine(title);
                foreach (byte b in bytes)
                {
                    System.Console.Write("{0:X} ", b);
                }
                System.Console.WriteLine();
        }

        private static void SerializeXML()
        {
            // MusicTrack track= new MusicTrack(){Artist="Belga", Title="1-2-3" , LengthInSeconds=180};

            // XmlSerializer musicTrackSerializer= new XmlSerializer(typeof(MusicTrack));
            // TextWriter serWriter=new StringWriter();
            // musicTrackSerializer.Serialize(serWriter,track);
            // serWriter.Close();
            // string trackXML=serWriter.ToString();
            // System.Console.WriteLine("Track XML:");
            // System.Console.WriteLine(trackXML);

            // TextReader serReader=new StringReader(trackXML);
            // MusicTrack trackRead=musicTrackSerializer.Deserialize(serReader) as MusicTrack;

            // System.Console.WriteLine("Read back: ");
            // System.Console.WriteLine($"{trackRead.Artist},{trackRead.Title},{trackRead.LengthInSeconds}");

        }
        
        private static void ConsoleStringFormaters()
        {
            int i= 99;
            double pi= 3.141592654;
            // System.Console.WriteLine(" {0,-10:D}{0, -10:X}{1,5:N2}",i,pi);
            // System.Console.WriteLine(" {0,10:D}{0, -10:X}{1,5:N2}",i,pi);
            // System.Console.WriteLine(" {0,10:D}{0, 10:X}{1,5:N2}",i,pi);
            // System.Console.WriteLine($"{i,0}");
            // System.Console.WriteLine($"{i,-10}");
            System.Console.WriteLine($"{i,10}{i,10}");
            System.Console.WriteLine($"{i,-10}{i,-10}");
        }

        private static void StringWriterTest()
        {
            StringWriter writer= new StringWriter();
            writer.WriteLine("Hello World");
            writer.Close();
            System.Console.WriteLine(writer.ToString());
            
        }

        private static void CallMethodWithReflection()
        {
            Child c = new Child();
            var type= c.GetType();
            var protectedMethod=type.GetMethod("ProtectedVoidWrapper");
            System.Console.WriteLine(protectedMethod.ToString());
            protectedMethod.Invoke(c,null);
        }
        private static void CheckAttribute()
        {
            System.Console.WriteLine(Attribute.IsDefined(typeof(ClassWithAttribute),typeof(SerializableAttribute)));
            var programmer=Attribute.GetCustomAttribute(typeof(ClassWithAttribute),typeof(ProgrammerAttribute));
            System.Console.WriteLine(((ProgrammerAttribute)programmer).Programmer);
            System.Console.WriteLine(nameof(programmer));
            Child c = new Child();
            var type= c.GetType();
            foreach (var member in type.GetMembers())
            {
                System.Console.WriteLine(member.ToString());
            }
        }
        private static void AttributeTests()
        {
            VerboseOrTerse();
            Verbose();
            Terse();
        }
        [Conditional("TERSE"),Conditional("VERBOSE")]
        static void VerboseOrTerse()=>System.Console.WriteLine("VerboseOrTerse");
        [Conditional("VERBOSE")]
        static void Verbose()=>System.Console.WriteLine("Verose");
        [Conditional("TERSE")]
        static void Terse()=>System.Console.WriteLine("Terse");
        private static void EasyerEnumeratorThingTest()
        {
            var e= new EasyerEnumeratorThing(20);
            foreach (var i in e)
            {
                System.Console.WriteLine(i);
            }
        }
        private static void EnumeratorTest()
        {
            EnumeratorThing e= new EnumeratorThing(100);
            foreach (int i in e)
            {
                System.Console.WriteLine(i);
            }
        }

        private static void  MathResultOrderTester()
        {
            var results=MathResult.GetResults();
            foreach (var r in results)
            {
                System.Console.WriteLine(r.Result);
            }
            results.Sort();
            foreach (var r in results)
            {
                System.Console.WriteLine(r.Result);
            }

        }
        private static void CastingTest()
        {
            Miles m= new Miles{Distance=1};
            Kilometers k=m;
            System.Console.WriteLine(k.Distance);

            Miles m2=k;
            System.Console.WriteLine(m2.Distance);

            m2.Distance=1.4;
            System.Console.WriteLine((int)m2);
            System.Console.WriteLine(k.Distance);
        }

        static void AlienTest()
        {
            Alien et;
            et.X=5;
            et.Y=11;
            et.Lives=5;
            System.Console.WriteLine(et);

            Alien et2= new Alien(10,11);
            System.Console.WriteLine(et2);
        }
        static void StructTest()
        {   
            Astruct a=new Astruct{Data=1};
            Astruct b=a;
            System.Console.WriteLine("This is the struct test");
            System.Console.WriteLine($"Value of a.Data={a.Data} ,b.Data={b.Data}");
            b.Data=2;
            System.Console.WriteLine("b has been set to 2");
            System.Console.WriteLine($"Value of a.Data={a.Data} ,b.Data={b.Data}");
            System.Console.WriteLine("/////////////////////////////////////");
        }

        static void ClassTest()
        {
            Aclass aclass= new Aclass{Data=1};
            Aclass b= aclass;
            System.Console.WriteLine("This is the class test");
            System.Console.WriteLine($"Value of a.Data={aclass.Data} ,b.Data={b.Data}");
            b.Data=2;
            System.Console.WriteLine("b has been set to 2");
            System.Console.WriteLine($"Value of a.Data={aclass.Data} ,b.Data={b.Data}");
            System.Console.WriteLine("/////////////////////////////////////");
        }

        static void AggregateExceptionTest()
        {
            try
            {
                Task<string> getpage= FetchWebPage("invalid");
                getpage.Wait();
                System.Console.WriteLine(getpage.Result);
            }
            catch (AggregateException ag)
            {
                foreach (var e in ag.InnerExceptions)
                {
                    System.Console.WriteLine("this is an inner exc");
                    System.Console.WriteLine(e.Message);
                }
            }
        }

        async static Task<string> FetchWebPage(string uri)
        {
            var httpClient= new HttpClient();
            var response= await httpClient.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }

        static void ExceptionTests()
        {
            try
            {
                throw new CalcException("lolka",CalcExceptionType.InvalidNumber);
            }
            catch (CalcException e) when (e.CalcExceptionType==CalcExceptionType.DivideByZero)
            {
                
                System.Console.WriteLine(e.CalcExceptionType);
            }
            catch (CalcException e) when (e.CalcExceptionType==CalcExceptionType.InvalidNumber)
            {
                
                System.Console.WriteLine(e.CalcExceptionType);
            }


        }
        static void DelegateDemo()
        {
            IntOperation operation = Add;
            operation += Substract;
            operation += Multiply;
            operation(10, 10);
            // foreach (var o in operation.GetInvocationList())
            // {
            //     System.Console.WriteLine(o.DynamicInvoke());
            // }
        }

        static void FuncTest()
        {
            Func<int,int,string> func=(a,b) => (a+b).ToString();
            func(10,2);
            
        }

        static int Add(int a, int b)
        {
            Console.WriteLine("Add called");
            return a + b;
        }
        static int Substract(int a, int b)
        {
            Console.WriteLine("Substract called");
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            Console.WriteLine("Multiply called");
            return a * b;
        }
        private static void AlarmWithActionDelegate()
        {
            Alarm a = new Alarm();
            a.OnAlarmRAised += (s, e) =>
            {
                System.Console.WriteLine(e.EventRaisedAt);
            };
            a.OnAlarmRAised += (s, e) =>
            {
                throw new NotImplementedException();
            };
            try
            {
                a.RaiseAlarm();
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    System.Console.WriteLine("This is written from the catch");
                    System.Console.WriteLine("------------------------------");
                    System.Console.WriteLine("------------------------------");
                    System.Console.WriteLine(e.ToString());
                }
            }
        }

        static void EventRaised()
        {
            System.Console.WriteLine("Event raised");
        }

        static int m1()
        {
            System.Console.WriteLine("m1 called");
            return 1;
        }
        static int m2()
        {
            System.Console.WriteLine("m2 called");
            return 2;
        }
        private static void OperatorTest()
        {
            if (m1() == 2 & m2() == 2)
            {
            }

            if (m1() == 2 && m2() == 2)
            {
            }

        }

        private static void ForEachFullNamePeople()
        {
            var people = Person.GetPeopleWithFullNamesList();
            foreach (var p in people)
            {
                p.FullName = new FullName() { Value = p.FullName.Value.ToUpper() };
            }
            foreach (var p in people)
            {
                System.Console.WriteLine(p.FullName.Value);
            }
        }

        private static void WriteFrom1to10()
        {
            for (int i = 1; i <= 10; i++)
            {
                System.Console.WriteLine(i);
            }
        }

        private static void IncrementFromMultipleTaskWrongly()
        {
            for (int i = 0; i < 1000; i++)
            {
                Task.Run(() =>
                {
                    totalAmount = totalAmount + 1;
                });
            }
            Thread.Sleep(1000);
            System.Console.WriteLine(totalAmount);
        }

        static void IncrementFromMultipleTask()
        {
            Task[] tasks = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                Task t = new Task(() =>
                {
                    IncrementThreadSafe();
                });
                tasks[i] = t;
                t.Start();
            }
            Task.WaitAll(tasks);
            System.Console.WriteLine(totalAmount);
        }
        static void IncrementThreadSafe()
        {
            Interlocked.Increment(ref totalAmount);
        }
        private static void TaskCancellationDemo()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task t = new Task(() =>
            {
                try
                {
                    while (!cts.IsCancellationRequested)
                    {
                        System.Console.WriteLine("Tick");
                        Thread.Sleep(1000);
                    }
                    cts.Token.ThrowIfCancellationRequested();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }
            });

            try
            {
                t.Start();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            System.Console.WriteLine("Press any key to stop the ticking");
            System.Console.ReadKey();
            cts.Cancel();
            System.Console.WriteLine("Clock stopped");
            Console.ReadKey();
        }


        private static void BlockingCollectionAsWrapper()
        {
            BlockingCollection<int> collection = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    collection.Add(i);
                    System.Console.WriteLine($"{i} added to the collection");
                    Thread.Sleep(100);
                }
                collection.CompleteAdding();
            });
            Thread.Sleep(100);
            System.Console.WriteLine("Press any key to start reading");
            System.Console.ReadKey();
            Task.Run(() =>
            {
                try
                {
                    while (!collection.IsCompleted)
                    {
                        Thread.Sleep(100);
                        System.Console.WriteLine($"{collection.Take()} was taken from the collection");
                    }
                }
                catch
                {
                    System.Console.WriteLine("There was an exception");
                }
            }).Wait();


        }

        private static void ThreadFromThreadPool()
        {
            for (int i = 0; i < 50; i++)
            {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(state => DoWork(stateNumber));
            }
            Console.ReadKey();
        }

        private static void ThreadLocalDemo()
        {
            ThreadLocal<Random> randomGenerator = new ThreadLocal<Random>(() =>
             {
                 return new Random(2);
             });
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Console.WriteLine("t1: {0}", randomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Console.WriteLine("t2: {0}", randomGenerator.Value.Next(10));
                    Thread.Sleep(500);
                }
            });

            t1.Start();
            t2.Start();
            Console.ReadKey();
        }


        private static void ThreadJoin()
        {
            Thread threadToWaitFor = new Thread(() =>
            {
                Thread.Sleep(10000);
                System.Console.WriteLine("Done");
            });
            threadToWaitFor.Start();
            System.Console.WriteLine("Joining thread");
            threadToWaitFor.Join();
            System.Console.WriteLine("Joined");
        }

        private static void ThreadAbortWithFlagDemo()
        {
            bool isStopped = false;
            Thread tickThread = new Thread(() =>
             {
                 while (!isStopped)
                 {
                     System.Console.WriteLine("tick");
                     Thread.Sleep(1000);
                 }
             });

            System.Console.WriteLine("Press a key to exit the clock");
            tickThread.Start();
            Console.ReadKey();
            isStopped = true;


        }

        private static void ThreadAbortDemo()
        {
            Thread tickThread = new Thread(() =>
             {
                 while (true)
                 {
                     System.Console.WriteLine("tick");
                     Thread.Sleep(1000);
                 }
             });

            System.Console.WriteLine("Press a key to exit the clock");
            tickThread.Start();
            Console.ReadKey();
            tickThread.Abort();
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        static void ThreadCreation()
        {
            Thread t = new Thread(() => DoWork());
            t.Start();

            var t2 = new Thread(() =>
            {
                System.Console.WriteLine("Yet another thread");
                Thread.Sleep(1000);
                System.Console.WriteLine("Ok Bye from this thread");
            });
            t2.Start();

            ParameterizedThreadStart ps = new ParameterizedThreadStart(PrintObj);
            var t3 = new Thread(ps);
            t3.Start();

            var t4 = new Thread((data) => PrintObj(data));
            t4.Start(89);

        }

        static void PrintObj(object i) => System.Console.WriteLine(i);

        public static void ChildTaskDemo()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                System.Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int taskNo = i;
                    Task.Factory.StartNew(
                        (x) => DoChild(x), taskNo, TaskCreationOptions.AttachedToParent
                    );
                }
            });
            parent.Wait();
            System.Console.WriteLine("Parent finished");
        }

        public static void DoChild(object state)
        {
            System.Console.WriteLine($"Child {state} starting");
            Thread.Sleep(1000);
            System.Console.WriteLine($"Child {state} finished");
        }

        public static void TaskContinuationWithPassedParam()
        {
            Task t1 = Task.Run(() =>
            {
                throw new NotImplementedException();
                return 15;
            })
                .ContinueWith((t) => System.Console.WriteLine("This wont be readable"), TaskContinuationOptions.OnlyOnRanToCompletion);
            t1.Wait();
        }

        public static void TaskContinuation()
        {
            Task t1 = Task.Run(() => HelloTask()).ContinueWith((prevTask) => WorldTask());
            t1.Wait();
        }

        public static void HelloTask()
        {
            Thread.Sleep(2000);
            System.Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(2000);
            System.Console.WriteLine("World");
        }

        public static void TaskWaitAll()
        {
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                tasks[j] = Task.Run(() => System.Console.WriteLine(j));
            }
            Task.WaitAll(tasks);
        }

        public static void CreateTasks()
        {
            Task t = new Task(DoWork);
            Task.Run(() => DoWork());
            t.Start();
            Task<int> t2 = new Task<int>(() => 5);
            t2.Start();
            System.Console.WriteLine(t2.Result);
        }

        public static void DoWork(object obj)
        {
            System.Console.WriteLine("Doing work {0}", obj);
            Thread.Sleep(500);
            System.Console.WriteLine("Work finished {0}", obj);
        }
        public static void DoWork()
        {
            System.Console.WriteLine("Doing work");
            Thread.Sleep(500);
            System.Console.WriteLine("Work finished");
        }
        private static void PLINQDemo()
        {
            // AsSequential() (the part of the query afther this will be executed after the parallel "tasks")
            // ForAll() (executed for every item)
            var people = Person.GetPersonList();
            var result = from p in people.AsParallel().AsOrdered()
                             .WithDegreeOfParallelism(3)
                             .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where p.City == "Aba"
                         select p;

            try
            {
                result.ForAll((p) =>
                {
                    if (p.Name == "Bence")
                    {
                        throw new ArgumentException();
                    }
                });
            }
            catch (AggregateException e)
            {
                System.Console.WriteLine(e.InnerExceptions.Count);
            }


            foreach (var p in result)
            {
                System.Console.WriteLine(p.Name);
            }

        }

        private static void ManageParallelForEach()
        {
            // if the  .Stop() is used then teh items lower then the actually iteration might not be completed
            // if the .Break() is used then every iteration will be completed which is lower then the break
            var items = Enumerable.Range(0, 100);
            ParallelLoopResult result = Parallel.ForEach(items, (int i, ParallelLoopState loopState) =>
              {
                  if (i == 80)
                  {
                      loopState.Break();
                      // loopState.Stop();
                  }
                  System.Console.WriteLine(i);
              });
            System.Console.WriteLine($"Lowest break iteration: {result.LowestBreakIteration}");
            System.Console.WriteLine(result.IsCompleted);
        }

        private static void ParallelFor()
        {
            Parallel.For(0, 10, (i) => { System.Console.WriteLine(i); });
        }
        private static void ParallelForEach()
        {
            var items = Enumerable.Range(0, 100);
            Parallel.ForEach(items, item => { System.Console.WriteLine(item); });
        }

        private static void ParallelInvoke()
        {
            Action[] actions = new Action[10];
            for (int i = 0; i < 10; i++)
            {
                int j = i + 1;
                actions[i] = new Action(() => { System.Console.WriteLine($"Written from action {j}"); Thread.Sleep(100); });
            }

            Parallel.Invoke(actions);
            System.Console.WriteLine("Parallel.Invoke returns when every action returned");
        }
    }
}
