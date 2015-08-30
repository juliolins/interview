using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class Kadane
    {
        public static void Test()
        {
            int[] array = new int[] { -1, -1, 5, -1, -1, -1, 4, -1};

            Console.WriteLine(MaxSum(array));
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
