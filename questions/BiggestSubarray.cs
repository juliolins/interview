using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BiggestSubarray
    {
        public static void Test()
        {
            int[] array = new int[] { -2, 4, 1, -8, 6, 3, -5};

            int left, right;

            LargestSubset(array, out left, out right);

            Console.WriteLine("Left = " + left);
            Console.WriteLine("Right = " + right);
        }

        public static void LargestSubset(int[] array, out int left, out int right)
        {
            left = right = 0;
            int sum = 0;
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                //current set is not worth it
                if (sum < 0)
                {
                    sum = 0;                    
                    left = i + 1;
                }

                if (sum > max)
                {
                    right = i;
                    max = sum;
                }
            }
        }

    }
}
