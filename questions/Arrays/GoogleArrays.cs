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
            int[] array = new int[] { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };
            Console.WriteLine(MinimumJumps(array));
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
    }
}
