using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    //[Facebook-Screen]Given the total number of points that a team scored,
    //count the number of possibilities that could lead into that result. The
    //possible ways to scores are 1,2,3,6,7. Tip: Make sure to give the
    //complexity of your solution.

    public class TeamScore
    {
        public static void Test()
        {
            //Console.WriteLine("Count(1)  = " + TheCount(1));
            //Console.WriteLine("Count(2)  = " + TheCount(2));
            Console.WriteLine("Count(6)  = " + TheCount(6));
            //Console.WriteLine("Count(6)  = " + TheCount(6));
        }
        
        public static int TheCount(int score)
        {
            DateTime start = DateTime.Now;
            Stack<int> numbers = new Stack<int>();
            Count(score, 0, numbers);
            DateTime end = DateTime.Now;

            Console.WriteLine("time: " + (end - start).TotalSeconds);

            return finalCount;
        }

        static int finalCount = 0;


        public static void Count(int score, int point, Stack<int> numbers)
        {
            int newScore = score - point;

            if (point != 0)
            {
                numbers.Push(point);
            }

            if (newScore == 0)
            {
                finalCount++;

                PrintNumbers(numbers);
            }

            if (newScore > 0)
            {
                //if (point <= 1)
                    Count(newScore, 1, numbers);

                //if (point <= 2)
                    Count(newScore, 2, numbers);
                
                //if (point <= 3)
                    Count(newScore, 3, numbers);

                //if (point <= 6)
                    Count(newScore, 6, numbers);

                Count(newScore, 7, numbers);
            }

            if (point != 0)
                numbers.Pop();
        }

        public static void PrintNumbers(Stack<int> numbers)
        {
            Stack<int> helpStack = new Stack<int>();

            Console.Write("List: ");
            while (numbers.Count > 0)
            {
                int number = numbers.Pop();
                helpStack.Push(number);

                Console.Write(number + ", ");
            }
            Console.WriteLine();

            while (helpStack.Count > 0)
            {
                numbers.Push(helpStack.Pop());
            }
        }
    }
}
