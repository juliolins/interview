using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingQuestions;

namespace ProgrammingQuestions.Sorting
{

    public class Sortings
    {
        public static void Test()
        {
            int[] a = new int[] { 3, 2, 5, 1, 9, 4, 8, 6, 7};
            a.PrintToConsole();
            MergeSort(a);
            a.PrintToConsole();
            a.AssertSorted();
        }

        public static void MergeSort(int[] array)
        {
            DoMergeSort(array, 0, array.Length - 1, new int[array.Length]);
        }

        private static void DoMergeSort(int[] array, int start, int end, int[] aux) 
        {
            if (start == end)
            {
                return;
            }

            int middle = (start + end) / 2;
            DoMergeSort(array, start, middle, aux);
            DoMergeSort(array, middle + 1, end, aux);
            Merge(array, start, middle, end, aux);
        }

        public static void Merge(int[] array, int start, int middle, int end, int[] aux)
        {
            for (int p = start; p <= end; p++)
            {
                aux[p] = array[p];
            }

            int i = start;
            int j = middle + 1;

            for (int k = start; k <= end; k++)
            {
                if (i > middle) array[k] = aux[j++];
                else if (j > end) array[k] = aux[i++];
                else if (array[i] > array[j]) array[k] = array[j++];
                else array[k] = array[i++];
            }
        }


        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        array.Swap(j, j - 1);
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int indexMin = i;
                int min = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        indexMin = j;
                        min = array[j];
                    }
                }

                array.Swap(i, indexMin);
            }
        }

    }

    public static class SortingExtensions
    {
        public static void AssertSorted(this int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    throw new Exception("Array is not sorted");
                }
            }
        }
    }
}
