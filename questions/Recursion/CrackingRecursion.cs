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

            //Console.WriteLine(CrackingRecursion.Fib(12));
            //Console.WriteLine(CrackingRecursion.FibIteractive(12));

            //Console.WriteLine(CrackingRecursion.HowManyPaths(10, 10) + "");

            //Console.WriteLine(Int64.MaxValue + "");

            //Console.WriteLine("All sets:");
            //var allSets = CrackingRecursion.AllSets(new int[] { 1, 2, 3, 4});
            //foreach (var set in allSets)
            //{
            //    set.PrintToConsole();
            //}

            //var allPermutations = CrackingRecursion.AllPermutations("abc");
            //allPermutations.PrintToConsole(true);

            var allParentesis = CrackingRecursion.AllParentesis(4);
            allParentesis.PrintToConsole(true);
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

        public static IEnumerable<string> AllPermutations(string word)
        {
            var permutations = new List<string>();
            Permute(word.ToCharArray(), 0, permutations);
            return permutations;
        }

        private static void Permute(char[] word, int startIndex, List<string> permutations)
        {
            if (startIndex == word.Length - 1)
            {
                permutations.Add(new string(word));
                return;
            }

            for (int i = startIndex; i < word.Length; i++)
            {
                word.Swap(startIndex, i);
                Permute(word, startIndex + 1, permutations);
                word.Swap(startIndex, i);
            }
        }

        public static IEnumerable<string> AllParentesis(int pairQuantity)
        {
            var allParentesis = new List<string>();
            Parentesis(new char[pairQuantity * 2], 0, pairQuantity, pairQuantity, allParentesis);
            return allParentesis;
        }

        public static void Parentesis(char[] array, int index, int left, int right, List<string> allParentesis)
        {
            if (left == 0 && right == 0)
            {
                allParentesis.Add(new string(array));
                return;
            }

            if (left > 0)
            {
                array[index] = '(';
                Parentesis(array, index + 1, left - 1, right, allParentesis);
            }

            if (right > 0 && right > left)
            {
                array[index] = ')';
                Parentesis(array, index + 1, left, right - 1, allParentesis);
            }
        }

        public static void Navigate(int[][] matrix, int i, int j, Func<int[][], int, int, bool> shoudlVisit, Action<int[][], int, int> visit)
        {
            if (i < 0 || i >= matrix.Length) return;
            if (j < 0 || j >= matrix[i].Length) return;

            if (shoudlVisit(matrix, i, j))
            {
                visit(matrix, i, j);

                Navigate(matrix, i - 1, j, shoudlVisit, visit);
                Navigate(matrix, i + 1, j, shoudlVisit, visit);
                Navigate(matrix, i, j - 1, shoudlVisit, visit);
                Navigate(matrix, i, j + 1, shoudlVisit, visit);
            }
        }
    }
}
