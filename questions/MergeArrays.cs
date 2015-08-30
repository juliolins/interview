using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class MergeArrays
    {
        public static void Test()
        {

            

            //int[] a = new int[] { 1, 2, 6, 8, 9, 0, 0, 0 };
            //int[] b = new int[] { 3, 4, 10};

            //Merge2(a, b, 5);

            //for (int i = 0; i < a.Length; i++)
            //{
            //    Console.Write(a[i] + ", ");
            //}

            //Console.WriteLine("\nCount = " + count);

            //int[] array = new int[] {15, 16, 19, 20, 25, 1, 3, 5, 7, 10, 14};
            //int pos = BinarySearch_Rotated(array, 16);
            //Console.WriteLine("Pos = " + pos);

            int[,] matrix = { {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16} };


            BinarySearch_Matrix(matrix, 3);
        }

        public static void BinarySearch_Matrix(int[,] matrix, int value)
        {
            int left_i = 0;
            int right_i = matrix.GetLength(0) - 1;

            int left_j = 0;
            int right_j = matrix.GetLength(1) - 1;

            int middle_i = 0;
            int middle_j = 0;

            //first find the line
            while (left_i <= right_i)
            {
                middle_i = (left_i + right_i) / 2;

                if (matrix[middle_i, right_j] == value)
                {
                    //lucky strike
                    Console.WriteLine(string.Format("Found i = {0} & j = {1}", middle_i, right_j));
                    return;
                }
                else if (matrix[middle_i, right_j] > value)
                {
                    right_i = middle_i - 1;
                }
                else
                {
                    left_i = middle_i + 1;
                }
            }

            //now find the column (final element)
            while (left_j <= right_j)
            {
                middle_j = (left_j + right_j) / 2;

                if (matrix[middle_i, middle_j] == value)
                {
                    Console.WriteLine(string.Format("Found i = {0} & j = {1}", middle_i, middle_j));
                    return;
                }
                else if (matrix[middle_i, middle_j] > value)
                {
                    right_j = middle_j - 1;
                }
                else
                {
                    left_j = middle_j + 1;
                }

            }

            

            //while (left_i <= right_i && left_j <= right_j)
            //{
            //    int middle_i = (left_i + right_i) / 2;
            //    int middle_j = (left_j + right_j) / 2;

            //    if (matrix[middle_i, middle_j] == value)
            //    {
            //        Console.WriteLine(string.Format("Found i = {0} & j = {1}", middle_i, middle_j));
            //        return;
            //    }
            //    else
            //    {

            //    }
            //}

        }

        public static int BinarySearch_Rotated(int[] array, int value)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (value == array[middle])
                {
                    return middle;
                }
                if (value >= array[left] && value <= array[middle])
                {
                    right = middle - 1;
                }
                else if (value >= array[middle] && value <= array[right])
                {
                    left = middle + 1;
                }
            }

            return -1;
        }


        static int count = 0;

        public static void Merge(int[] a, int[] b, int offset)
        {
            //copy b to a[offset]
            for (int i = 0; i < b.Length; i++)
            {
                a[i + offset] = b[i];
            }

            for (int i = 0; i < offset; i++)
            {
                for (int j = offset; j < a.Length; j++)
                {
                    count++;

                    if (a[i] > a[j])
                        Swap(a, i, j);                    
                }
            }
        }

        public static void Merge2(int[] a, int[] b, int offset)
        {
            int indexA = offset - 1;
            int indexB = b.Length - 1;
            int current = a.Length - 1;

            while (indexB >= 0)
            {
                count++;

                if (a[indexA] >= b[indexB])
                {
                    a[current] = a[indexA];
                    indexA--;
                }
                else
                {
                    a[current] = b[indexB];
                    indexB--;
                }

                current--;
            }
        }


        public static void Swap(int[] x, int i, int j)
        {
            int temp = x[i];
            x[i] = x[j];
            x[j] = temp;
        }

    }
}
