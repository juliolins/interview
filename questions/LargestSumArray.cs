using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    class LargestSumArray
    {
        public static void Test()
        {
            int[] array = new int[] { 2, -8, 3, -2, 4, -10 };

            Console.WriteLine(MaxSum(array));
        }

        public static int MaxSum(int[] array)
        {
            int maxSum = 0;
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                else if (currentSum < 0)
                {
                    currentSum = 0;
                }

            }

            return maxSum;
        }

    }
}
