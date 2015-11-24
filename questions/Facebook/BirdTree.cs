using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Facebook
{
    public class BirdTree
    {
        public static void Test()
        {
            int[] array = new int[] { 10, 10, 1, 1, 1, 1, 1, 10, 10};

            Console.WriteLine(MaxValue(array, 4));
        }

        public static int MaxValue(int[] array, int windowSize)
        {
            int sum = 0;

            for (int i = 0; i < windowSize; i++)
            {
                sum += array[i];
            }

            int max = sum;

            for (int i = windowSize ; i < array.Length + windowSize - 1; i++)
            {
                sum = sum + array[i % array.Length] - array[i - windowSize];
                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}
