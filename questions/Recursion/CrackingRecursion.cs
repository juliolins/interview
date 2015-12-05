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

            //var allParentesis = CrackingRecursion.AllParentesis(4);
            //allParentesis.PrintToConsole(true);

            //int[][] matrix = new int[][] 
            //{
            //    new int[] {1, 0, 0, 1},
            //    new int[] {1, 1, 0, 0},
            //    new int[] {0, 1, 1, 1},
            //    new int[] {1, 1, 0, 1}
            //};

            //int color = 1;
            //CrackingRecursion.Navigate(matrix, 0, 0, (theMatrix, i, j) => theMatrix[i][j] == color, (theMatrix, i, j) => theMatrix[i][j] *= -1);

            //foreach (var line in matrix)
            //{
            //    line.PrintToConsole();
            //}

            //Console.WriteLine("Count = " + CrackingRecursion.NumberOfWaysCoins(100));
            //Console.WriteLine("Cost: " + CrackingRecursion.cost);

            Console.WriteLine(CrackingRecursion.IsThereSumZero2(new int[]{-1, 2, -3, 1}));
        }
    }


    public class CrackingRecursion
    {
        public static int cost = 0;

        public static int NumberOfWaysCoins(int amount)
        {
            int[][] cache = new int[amount + 1][];
            for (int i = 0; i < cache.Length; i++)
			{
			    cache[i] = new int[6];
			}

            return NumberOfWaysCoins(amount, 25, cache);
        }

        public static int NumberOfWaysCoins(int amount, int maxCoin, int[][] cache)
        {
            cost++;

            if (cache[amount][maxCoin / 5] > 0)
            {
                return cache[amount][maxCoin / 5];
            }

            if (amount == 0)
            {
                return 1;
            }

            int count = 0;

            if (amount >= 25 && maxCoin >= 25)
            {
                count += NumberOfWaysCoins(amount - 25, 25, cache);
            }

            if (amount >= 10 && maxCoin >= 10)
            {
                count += NumberOfWaysCoins(amount - 10, 10, cache);
            }
            if (amount >= 5 && maxCoin >= 5)
            {
                count += NumberOfWaysCoins(amount - 5, 5, cache);
            }
            if (amount >= 1 && maxCoin >= 1)
            {
                count += NumberOfWaysCoins(amount - 1, 1, cache);
            }

            cache[amount][maxCoin / 5] = count;

            return count;
        }


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

        //Given an array of integers, find whether there are 3 of them which sum to 0.
        public static bool IsThereSumZero(int[] array)
        {
            return IsThereSumZero(array, 0, 0, 3);
        }

        private static bool IsThereSumZero(int[] array, int start, int sum, int toGo)
        {
            if (toGo == 0)
            {
                return sum == 0;
            }

            for (int i = start; i < array.Length; i++)
            {
                if (IsThereSumZero(array, i + 1, sum + array[i], toGo - 1))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsThereSumZero2(int[] array)
        {
            Array.Sort(array);

            for (int i = 0; i < array.Length - 2; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;

                while (left < right)
                {
                    int sum = array[i] + array[left] + array[right];

                    if (sum == 0)
                    {
                        return true;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return false;
        }

    }
}
