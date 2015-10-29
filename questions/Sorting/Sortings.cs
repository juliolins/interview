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
            int[] a = new int[] { 3, 2, 5, 1, 9, 4, 8, 6, 7 };
            a.PrintToConsole();
            FindLargestElements(a, 3).PrintToConsole();
            QuickSort(a);
            a.PrintToConsole();
            a.AssertSorted();

            //Console.WriteLine("Number of inversions: " + numberOfInversions);

            Console.WriteLine("Index of 3 = " + BinarySearchIteractive(a, -1));
        }

        public static int BinarySearchIteractive(int[] array, int value)
        {
            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;
                if (array[middle] > value) end = middle - 1;
                else if (array[middle] < value) start = middle + 1;
                else return middle;
            }

            return -1;
        }

        //returns the index of value
        private static int BinarySearch(int[] array, int value)
        {
            return DoBinarySearch(array, value, 0, array.Length - 1);
        }

        private static int DoBinarySearch(int[] array, int value, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int middle = (start + end) / 2;

            if (array[middle] > value)
            {
                return DoBinarySearch(array, value, start, middle - 1);
            }
            else if (array[middle] < value)
            {
                return DoBinarySearch(array, value, middle + 1, end);
            }
            else
            {
                return middle;
            }
        }

        public static IEnumerable<int> FindLargestElements(int[] array, int k)
        {
            int index = array.Length - k;

            int low = 0;
            int high = array.Length - 1;
            int partition = -1;

            while (true)
            {
                partition = Partition(array, low, high);
                if (partition < index) low = partition + 1;
                else if (partition > index) high = partition - 1;
                else break;
            }

            return array.Skip(array.Length - k);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (end <= start)
            {
                return;
            }

            int partition = Partition(array, start, end);
            QuickSort(array, start, partition - 1);
            QuickSort(array, partition + 1, end);
        }


        public static int Partition(int[] array, int start, int end)
        {
            int i = start;
            int j = end + 1;

            while (i < j)
            {
                while (++i < end && array[i] <= array[start]);

                while (--j > start && array[j] >= array[start]);

                if (i > j) break;
                array.Swap(i, j);
            }

            array.Swap(start, j);

            return j;
        }

        private static int numberOfInversions = 0;
        public static void BottonUpMergeSort(int[] array)
        {
            int[] aux = new int[array.Length];
            int step = 1;

            while (step < array.Length)
            {
                for (int i = 0; i < array.Length - step; i += step)
                {
                    Merge(array, i, i + (step / 2), Math.Max(i + step, array.Length - 1), aux);
                }

                step *= 2;
            }
        }

        public static void MergeSort(int[] array)
        {
            DoMergeSort(array, 0, array.Length - 1, new int[array.Length]);
        }

        public static void HalfAuxMergeSort(int[] array)
        {
            DoHalfSizeMergeSort(array, 0, array.Length - 1, new int[array.Length / 2 + 1]);
        }

        private static void DoHalfSizeMergeSort(int[] array, int start, int end, int[] aux)
        {
            if (start == end)
            {
                return;
            }

            int middle = (start + end) / 2;
            DoHalfSizeMergeSort(array, start, middle, aux);
            DoHalfSizeMergeSort(array, middle + 1, end, aux);
            MergeHalfArray(array, start, middle, end, aux);
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
                else if (aux[i] > aux[j]) { array[k] = aux[j++]; numberOfInversions++; }
                else array[k] = aux[i++];
            }
        }

        public static void MergeHalfArray(int[] array, int start, int middle, int end, int[] aux)
        {
            for (int p = 0; p <= (middle - start); p++)
            {
                aux[p] = array[start + p];
            }

            int i = 0;
            int j = middle + 1;

            for (int k = start; k <= end; k++)
            {
                if ((i + start) > middle) array[k] = array[j++];
                else if (j > end) array[k] = aux[i++];
                else if (aux[i] > array[j]) array[k] = array[j++];
                else array[k] = aux[i++];
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
