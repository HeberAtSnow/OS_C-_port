using System;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlock
{
    class Deadlock
    {
        public static object lock1 = new object();
        public static object lock2 = new object();
        static void Main(string[] args)
        {
            //create threads
            Thread t1 = new Thread(ThreadProcOne);
            Thread t2 = new Thread(ThreadProcTwo);
            //start threads
            t1.Start();
            t2.Start();
            //wait for threads to join
            t1.Join();
            t2.Join();
            
            Console.WriteLine("Finished");

        }


        public static void ThreadProcOne()
        {
            Console.WriteLine("Thread 1: Trying to Get Lock 1");
            lock (lock1)
            {
                Console.WriteLine("Thread 1: Lock 1 Obtained");
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1: Trying to Get Lock 2");
                lock (lock2)
                {
                    Console.WriteLine("Thread 1: Done");
                }
            }
        }


        public static void ThreadProcTwo()
        {
            Console.WriteLine("Thread 2: Trying to Get Lock 2");
            lock (lock2)
            {
                Console.WriteLine("Thread 2: Lock 2 Obtained");
                Thread.Sleep(1000);
                Console.WriteLine("Thread 2: Trying to Get Lock 1");
                lock (lock1)
                {
                    Console.WriteLine("Thread 2: Done");
                }
            }
        }
    }
}
