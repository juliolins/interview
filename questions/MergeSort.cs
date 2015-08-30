using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class MergeSort
    {
        public static void Test()
        {
            //int[] array = new int[] { 2, 4, 8, 5, 6, 3, 1, 7, 9 };


            int[] array = new int[] { 4, 3, 2, 1 };

            //int[] array = new int[10000000];
            //Random r = new Random();

            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = r.Next(10000000);
            //}


            Console.WriteLine("start");
            DateTime start = DateTime.Now;
            Sort(array);
            DateTime end = DateTime.Now;
            Console.WriteLine("end");

            Console.WriteLine("Seconds = " + (end - start).TotalSeconds);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("Count = " + count);
        }

        public static void InsertionSort(int[] array, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = i; j > start; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

        }

        public static void SelectionSort(int[] array, int start, int end)
        {

            for (int i = start; i <= end; i++)
            {
                for (int j = i; j <= end; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void Sort(int[] array)
        {
            int[] tempArray = new int[array.Length / 2 + 1];
            SortRecursive(array, tempArray, 0, array.Length - 1);
        }

        public static void SortRecursive(int[] array, int[] tempArray, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int middle = (end + start) / 2;

            SortRecursive(array, tempArray, start, middle);
            SortRecursive(array, tempArray, middle + 1, end);
            Merge(array, tempArray, start, middle, middle + 1, end);
        }

        static int count = 0;

        public static void Merge(int[] array, int[] tempArray, int leftStart, int leftEnd, int rightStart, int rightEnd)
        {
            //assumption, the two arrays combined are continuous
            int size = rightEnd - leftStart + 1;
            int i = leftStart, j = rightStart, k = 0;

            for (i = leftStart, k = 0; i <= leftEnd; i++, k++)
            {
                tempArray[k] = array[i];
            }

            
            int iLimit = (leftEnd - leftStart); 

            for (k = leftStart, i = 0; k <= rightEnd; k++)
            {
                if (i > iLimit) //no more left elements
                {
                    array[k] = array[j++];
                }
                else if (j > rightEnd) //no more right elements
                {
                    array[k] = tempArray[i++];
                }
                else if (tempArray[i] <= array[j]) //left element is smaller
                {
                    array[k] = tempArray[i++];
                }
                else
                {
                    array[k] = array[j];

                    count += j - k;
                    j++;
                }
            }

            //k = 0;
            //for (i = leftStart; i <= rightEnd; i++)
            //{
            //    array[i] = tempArray[k++];
            //}
        }


    }

    public static class MyExtension2
    {
        public static string ToBeautifulString(this int[] array)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);

                if (i < array.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append("}");

            return builder.ToString();
        }

    }

}

