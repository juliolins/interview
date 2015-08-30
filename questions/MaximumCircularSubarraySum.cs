using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    /*
Given n numbers (both +ve and -ve), arranged in a circle, fnd the maximum sum of consecutive number.
Examples:

Input: a[] = {8, -8, 9, -9, 10, -11, 12}
Output: 22 (12 + 8 - 8 + 9 - 9 + 10)

Input: a[] = {10, -3, -4, 7, 6, 5, -4, -1} 
Output:  23 (7 + 6 + 5 - 4 -1 + 10) 

Input: a[] = {-1, 40, -14, 7, 6, 5, -4, -1}
Output: 52 (7 + 6 + 5 - 4 - 1 - 1 + 40)
Sources: Microsoft Interview Question and Microsoft
     */
    public class MaximumCircularSubarraySum
    {
        public static void Test()
        {
            int[] array = { -3, -5, 4, 5, -10, 3, 2, -8 };

            Console.WriteLine(MaxSum(array));
            
        }

        public static int MaxSum(int[] array)
        {
            int sum = 0;
            int max = 0;

            int left = 0;
            int right = 0;

            int maxLeft = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if (sum < 0)
                {
                    left = i + 1;
                    sum = 0;
                } 
                else if (sum > max)
                {
                    maxLeft = left;
                    right = i;
                    max = sum;
                }
            }

            Console.WriteLine("[left = {0}, right = {1}]", maxLeft, right);

            return max;
        }

    }
}
