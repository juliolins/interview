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
            InsertionSort(a);
            a.PrintToConsole();
            a.AssertSorted();
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
