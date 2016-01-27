using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Dynamic
{
    public class SubsetDifference
    {
        public static void Test()
        {
            int[] a = new int[] { 1, 6, 11, 5 };
            Console.WriteLine(MinDifference(a));
        }

        public static int MinDifference(int[] array)
        {
            return MinDifference(array, 0, 0, 0);
        }

        public static int MinDifference(int[] array, int start, int sumLeft, int sumRight)
        {
            if (start == array.Length)
            {
                return Math.Abs(sumLeft - sumRight);
            }

            int left = MinDifference(array, start + 1, sumLeft + array[start], sumRight);
            int right = MinDifference(array, start + 1, sumLeft, sumRight + array[start]);

            return Math.Min(left, right);
        }
    }
}
