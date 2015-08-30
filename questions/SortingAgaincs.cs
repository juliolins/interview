using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    class SortingAgain
    {
        public static void Test()
        {
            int[] array = new int[] { 4, 2, 5, 1, 3, 8, 7, 9, 6, 10};

            array.PrintToConsole();

            QuickSort(array);

            array.PrintToConsole();

            Console.WriteLine(Find(array, 10));
        }


        public static void QuickSort(int[] array)
        {
            DoQuickSort(array, 0, array.Length - 1);
        }

        private static void DoQuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int j = Partition(array, start, end);

            DoQuickSort(array, start, j - 1);
            DoQuickSort(array, j + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int i = start + 1;
            int j = end;

            while (true)
            {
                while (array[i] < array[start] && i <= end) i++;

                while (array[j] >= array[start] && j > start) j--;

                if (j < i) break;

                array.Swap(i, j);
            }

            array.Swap(start, j);

            return j;
        }

        public static int Find(int[] array, int value)
        {
            return DoFind(array, value, 0, array.Length);
        }

        public static int DoFind(int[] array, int value, int start, int end)
        {
            int middle = (start + end) / 2;

            if (array[middle] == value)
            {
                return middle;
            }
            else if (value < array[middle])
            {
                return DoFind(array, value, start, middle);
            }
            else if (value > array[middle])
            {
                return DoFind(array, value, middle + 1, end);
            }

            return -1;
        }
    }
}
