using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class CircularShift
    {

        public static void Shift(char[] array, int n, int k)
        {
            if (k == 0) return;

            bool isNegative = (k < 0);
            k = Math.Abs(k) % n;

            if (isNegative)
            {
                k = n - k;
            }

            //reverse all array
            Reverse(array, 0, n - 1);
            
            //un-reverse first part (up to k-1)
            Reverse(array, 0, k - 1);

            //unreverse second part
            Reverse(array, k, n - 1);
        }

        private static void Reverse(char[] array, int start, int end)
        {
            int middle = (end - start) / 2;
            for (int i = 0; i < middle; i++)
            {
                Swap(array, start + i, end - i);
            }
        }

        private static void Swap(char[] array, int i, int j)
        {
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }
}
