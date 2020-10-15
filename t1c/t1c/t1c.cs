using System;
using System.Collections.Generic;
using System.Threading;

namespace t1c
{
    class t1c
    {
        private static object m_lock = new object();
        private static int tally;
        private const int MAX = 50000;
        static void Main(string[] args)
        {
            //create threads
            Thread t1 = new Thread(ThreadProc);
            Thread t2 = new Thread(ThreadProc);

            t1.Name = "Thread 1";
            t2.Name = "Thread 2";

            //start threads
            t1.Start();
            t2.Start();

            //join threads
            t1.Join();
            t2.Join();

            //output counter
            Console.WriteLine("Actual Tally: {0}", tally);
            Console.WriteLine("Expected Tally: {0}", MAX * 2);
        }


        public static void ThreadProc()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " has started");
            for (int i = 0; i < MAX; i++)
            {
                lock(m_lock)
                {
                    tally++;
                }
            }
            Console.WriteLine(Thread.CurrentThread.Name + " has finished");
        }
    }
}
