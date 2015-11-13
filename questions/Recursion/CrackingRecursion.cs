using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Recursion
{

    public class RecursionTest 
    {
        public static void Test()
        {

            Console.WriteLine(CrackingRecursion.Fib(12));
            Console.WriteLine(CrackingRecursion.FibIteractive(12));

            Console.WriteLine(CrackingRecursion.HowManyPaths(10, 10) + "");

            Console.WriteLine(Int64.MaxValue + "");

            Console.WriteLine("All sets:");
            var allSets = CrackingRecursion.AllSets(new int[] { 1, 2, 3, 4});
            foreach (var set in allSets)
            {
                set.PrintToConsole();
            }
        }
    }


    public class CrackingRecursion
    {


        public static int Fib(int x)
        {
            if (x <= 1) return x;
            else return Fib(x - 1) + Fib(x - 2);
        }

        public static int FibIteractive(int x)
        {
            if (x <= 1) return x;

            int a = 0;
            int b = 1;

            for (int i = 2; i < x; i++)
            {
                b = a + b;
                a = b - a;
            }

            return a + b;
        }

        public static int HowManyPaths(int X, int Y)
        {
            return HowManyPaths(1, 1, X, Y);
        }

        public static int HowManyPaths(int i, int j, int X, int Y)
        {
            if (i > X || j > Y) return 0;
            if (i == X && j == Y) return 1;

            return HowManyPaths(i + 1, j, X, Y) + HowManyPaths(i, j + 1, X, Y);
        }

        public static IEnumerable<IEnumerable<int>> AllSets(int[] array)
        {
            var allSets = new List<IEnumerable<int>>();
            allSets.Add(new List<int>());

            //generate sets of 1 to N-1 elements
            for (int i = 1; i < array.Length; i++)
            {
                BuildSet(array, 0, i, new Stack<int>(), allSets);
            }

            //self is set
            allSets.Add(array);

            return allSets;
        }

        private static void BuildSet(int[] array, int startIndex, int elements, Stack<int> stack, List<IEnumerable<int>> allSets)
        {
            if (elements == 0)
            {
                allSets.Add(stack.Reverse().ToList());
                return;
            }

            for (int i = startIndex; i < array.Length; i++)
            {
                stack.Push(array[i]);
                BuildSet(array, i + 1, elements - 1, stack, allSets);
                stack.Pop();
            }
        }
    }
}
