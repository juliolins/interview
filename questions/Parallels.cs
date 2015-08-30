using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProgrammingQuestions
{

    public class ParallelsTest
    {
        public static void Test()
        {
            //Paralelo paralelo = new Paralelo();

            //paralelo.DoSomething().Wait();
            //Console.WriteLine("Returned");

            //Thread.Sleep(2000);
            string s = "a";
            Console.WriteLine(s.GetHashCode());
        }


    }

    public class Paralelo
    {

        public async Task DoSomething()
        {
            Task task = new Task(() => {
                Thread.Sleep(500);
                Console.WriteLine("Task done"); 
            });

            task.Start();

            await task;

            Console.WriteLine("Returning");
        }

    }
}
