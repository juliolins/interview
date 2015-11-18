using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Sorting
{
    public class CrackingSortingTest
    {
        public static void Test()
        {
            //int[] a = new int[] { 1, 3, 5, 7, 9, 0, 0, 0, 0, 0};
            //int[] b = new int[] { 2, 4, 6, 8, 10 };

            //CrackingSorting.MergeSortedArrays(a, b);
            //a.PrintToConsole();

            int[] a = new int[] { 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            a.PrintToConsole();
            int x = 6;
            Console.WriteLine("x = " + x + " & i = " + CrackingSorting.BinarySearchRotated(a, x));
        }
    }

    public class CrackingSorting
    {
        public static void MergeSortedArrays(int[] a, int[] b)
        {
            int indexA = (a.Length - 1) - b.Length;
            int indexB = b.Length - 1;

            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (indexA < 0)
                {
                    a[i] = b[indexB--];
                }
                else if (indexB < 0)
                {
                    a[i] = a[indexA--];
                } 
                else if (a[indexA] >= b[indexB]) 
                {
                    a[i] = a[indexA--];
                }
                else
                {
                    a[i] = b[indexB--];
                }
            }
        }

        public static int BinarySearchRotated(int[] array, int value)
        {
            return BSR(array, value, 0, array.Length - 1);
        }

        public static int BSR(int[] array, int value, int left, int right)
        {
            if (left > right) return -1;

            int middle = (left + right) / 2;

            if (value == array[middle])
            {
                return middle;
            }
            if (array[left] <= array[middle]) //if left side is sorted
            {
                if (value >= array[left] && value < array[middle])
                {
                    return BSR(array, value, left, middle - 1);
                }
                else
                {
                    return BSR(array, value, middle + 1, right);
                }
            }
            else //right side is sorted
            {
                if (value > array[middle] && value <= array[right])
                {
                    return BSR(array, value, middle + 1, right);
                }
                else
                {
                    return BSR(array, value, left, middle - 1);
                }
            }
        }
    }
}
