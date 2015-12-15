using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class CrackingNumbers    
    {
        public static void Test()
        {
            //Console.WriteLine(Count2s(300));

            FindKthLargestElements(new int[] {27, 43, 23, 5, 2, 8, 3, 1, 32, 65, 42 }, 4).PrintToConsole();
        }

        public static int Count2s(int number)
        {
            if (number < 2) 
            {
                return 0;
            }
            else if (number <= 10)
            {
                return 1;
            }
            else if (number <= 30)
            {
                return Math.Max(0, number - 20) + (number / 10); 
            }
            else if (number <= 100)
            {
                return (number - 30) / 10 + Count2s(30);
            }
            else
            {
                return (number / 100) * 19 + Count2s(number % 100);
            }
        }

        public static int[] FindKthLargestElements(int[] array, int k)
        {
            int start = 0;
            int end = array.Length - 1;

            int partition = Partition(array, start, end);

            while (partition != k)
            {
                if (partition < k)
                {
                    start = partition + 1;
                }
                else
                {
                    end = partition - 1;
                }

                partition = Partition(array, start, end);
            }

            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = array[i];
            }
            return result;
        }

        private static int Partition(int[] array, int start, int end)
        {
            int i = start + 1;
            int j = end;

            while (i <= j)
            {
                while (array[i] >= array[start]) i++;
                while (array[j] <= array[start]) j--;

                if (i > j) break;

                array.Swap(i, j);
            }

            array.Swap(start, j);

            return j;
        }
    }
}
