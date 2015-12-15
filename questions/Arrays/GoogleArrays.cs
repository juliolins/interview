using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Arrays
{
    public class GoogleArrays
    {

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
    }
}
