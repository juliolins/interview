using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ProgrammingQuestions
{
    public class ReadWriteSimulation
    {
        private static ManualResetEvent writeLock = new ManualResetEvent(true);
        private static ManualResetEvent readLock = new ManualResetEvent(true);

        private static Random random = new Random();
        private SafeList<string> output;

        public ReadWriteSimulation(SafeList<string> output)
        {
            this.output = output;
        }

        public void Read()
        {
            writeLock.WaitOne();


            output.Add("[" + Thread.CurrentThread.ManagedThreadId + "]" + "Reading");

        }

        public void Write()
        {

            try
            {
                writeLock.WaitOne();
                writeLock.Reset();

                output.Add("[" + Thread.CurrentThread.ManagedThreadId + "]" + "Start write");
                Thread.Sleep(random.Next(11));
                output.Add("[" + Thread.CurrentThread.ManagedThreadId + "]" + "End write");

            }
            finally
            {
                writeLock.Set();
            }
        }

        public void RunReader()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(random.Next(11));
                Read();
            }
        }

        public void RunWriter()
        {
            for (int i = 0; i < 20; i++)
            {
                Write();
            }
        }
        

        public static void Test()
        {
            SafeList<string> list = new SafeList<string>();

            Thread tr1 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunReader));
            Thread tr2 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunReader));
            Thread tr3 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunReader));
            Thread tr4 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunReader));
            Thread tr5 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunReader));
            Thread tr6 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunReader));

            Thread tw1 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunWriter));
            Thread tw2 = new Thread(new ThreadStart(new ReadWriteSimulation(list).RunWriter));

            tr1.Start();
            tr2.Start();
            tr3.Start();
            tr4.Start();
            tr5.Start();
            tr6.Start();

            tw1.Start();
            tw2.Start();

            tr1.Join();
            tr2.Join();
            tr3.Join();
            tr4.Join();
            tr5.Join();
            tr6.Join();

            tw1.Join();
            tw2.Join();

            foreach (string item in list.GetList())
            {
                Console.WriteLine(item);
            }
        }
    }

    public class SafeList<T>
    {
        private AutoResetEvent listLock = new AutoResetEvent(true);
        private List<T> list = new List<T>();

        public void Add(T element)
        {
            lock (list)
            {
                list.Add(element);
            }

            //listLock.WaitOne();
            //listLock.Set();
        }

        public List<T> GetList()
        {
            return list;
        }
    }
}
