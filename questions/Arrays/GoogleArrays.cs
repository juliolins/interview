using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Arrays
{
    public class GoogleArrays
    {
        public static void Test()
        {
            //int[] array = new int[] { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };
            //Console.WriteLine(MinimumJumps(array));
            
            //int[] array = new int[] {1, 1, 2, 2, 2, 2, 3};
            //Console.WriteLine(CountOccurrences(array, 2));

            bool[][] array = new bool[10][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new bool[10];
            }

            DrawLine(array, 1, 1, 2, 8);
            PrintLine(array);
        }

        //https://en.wikipedia.org/wiki/Bresenham's_line_algorithm
        //Draw a line on 2D array of boolean
        public static void DrawLine(bool[][] array, int x1, int y1, int x2, int y2)
        {
            //first point
            double a = (x1 != x2) ? (double)(y2 - y1) / (double)(x2 - x1) : 0;
            double b = y2 - a * x2;

            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    //check if the point belongs to the line
                    int y = (int)(a * i + b);
                    if (j == y) 
                        array[i][j] = true;
                }
            }
        }



        //http://www.geeksforgeeks.org/minimum-number-of-swaps-required-for-arranging-pairs-adjacent-to-each-other
        /*
         * input:
         * pairs[] = {1->3, 2->6, 4->5}  // 1 is partner of 3 and so on
         * arr[] = {3, 5, 6, 4, 1, 2}
         * Output: 2
         * We can get {3, 1, 5, 4, 6, 2} by swapping 5 & 6, and 6 & 1
         */
        public static int CountSwaps(int[] array, IDictionary<int, int> pairs)
        {
            int swaps = 0;

            //check every other number
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                if (array[i + 1] == pairs[array[i]]) continue;

            }

            return swaps;
        }

        //http://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/
        //Minimum number of jumps to reach end
        //Input: arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
        //Output: 3 (1-> 3 -> 8 ->9)
        public static int MinimumJumps(int[] array)
        {
            return Jump(array, 0, new int[array.Length]);
        }

        private static int Jump(int[] array, int position, int[] cache)
        {
            if (position >= array.Length - 1)
            {
                return 0;
            }

            if (cache[position] > 0)
            {
                return cache[position];
            }

            int jumps = int.MaxValue;

            for (int i = 1; i <= array[position]; i++)
            {
                int pathJumps = Jump(array, position + i, cache);

                if (pathJumps < jumps)
                {
                    jumps = pathJumps;
                }
            }

            cache[position] = jumps + 1;
            return cache[position];
        }

        //Count the number of occurrences in a sorted array
        public static int CountOccurrences(int[] array, int number)
        {
            int left = 0;
            int right = array.Length - 1;
            int start = -1;
            //binary search to find the start
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[middle] == number)
                {
                    if (middle == left || (middle > left && array[middle - 1] != number))
                    {
                        start = middle;
                        break;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
                else if (array[middle] > number)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            //not found
            if (start == -1) return 0;

            int end = -1;
            left = start;
            right = array.Length - 1;
            //binary search to find the start
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[middle] == number)
                {
                    if (middle == right || (middle < right && array[middle + 1] != number))
                    {
                        end = middle;
                        break;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else if (array[middle] > number)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return end - start + 1;
        }

        public static void PrintLine(bool[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < array[0].Length; j++)
                {
                    Console.Write(array[i][j] ? "1 " : "0 ");
                }
            }
        }
    }
}
