using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class MaxSumArray
    {

        //http://www.geeksforgeeks.org/maximum-contiguous-circular-sum/

        public static void Test()
        {
          //int[] array = new int[] { 3, 4, -5, 2, 9, -7, -6, 8 };
          //int[] array = new int[] { -3, -4, 5, -2, -9, 7, 6, -8 };

            int[] array = new int[] { 3, 3, -7, -30, 5, -7, -30, 3 };

            Console.WriteLine("Normal= " + MaxSum(array));
            Console.WriteLine("Circularl= " + MaxSumCircular(array));
        }

        public static int MaxSumCircular(int[] array)
        {
            int kadaneSum = MaxSum(array);

            int totalSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                totalSum += array[i];

                array[i] = -array[i];
            }

            int kadaneInvertedSum = MaxSum(array);

            int inventedSum = totalSum + kadaneInvertedSum;

            return Math.Max(inventedSum, kadaneSum);
        }

        public static int MaxSum(int[] array)
        {
            int sum = 0;
            int maxSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                if (sum < 0)
                {
                    sum = 0;
                }
            }

            return maxSum;
        }
    }
}
