using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Arrays
{
    public class CrackingArrays
    {
        public static void TestRotate()
        {
            //int[][] matrix = new int[][] 
            //{
            //    new int[] {1, 2, 3},
            //    new int[] {4, 5, 6},
            //    new int[] {7, 8, 9}
            //};

            //Print(matrix);
            //Console.WriteLine();
            //Rotate(matrix);
            //Print(matrix);

            int[][] matrix = new int[][] 
            {
                new int[] {1, 2, 3},
                new int[] {4, 0, 6},
                new int[] {7, 8, 9}
            };

            Print(matrix);
            Console.WriteLine();
            SetRowColumnToZero(matrix);
            Print(matrix);

        }

        private static void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Rotate(int[][] matrix)
        {
            int start = 0;
            int end = matrix.Length - 1;

            while (start < end)
            {
                for (int i = 0; i < end - start; i++)
                {
                    //copy 1 to 3
                    int tempA = matrix[start + i][end];
                    matrix[start + i][end] = matrix[start][start + i];

                    //copy 3 to 9
                    int tempB = matrix[end][end - i];
                    matrix[end][end - i] = tempA;

                    //copy 9 to 7
                    tempA = matrix[end - i][start];
                    matrix[end - i][start] = tempB;

                    //copy 7 to 1
                    matrix[start][start + i] = tempA;
                }

                start++;
                end--;
            }
        }

        public static void SetRowColumnToZero(int[][] matrix)
        {
            bool[] setZero_i = new bool[matrix.Length];
            bool[] setZero_j = new bool[matrix[0].Length];

            //scan matrix markings rows and columns as set to zero
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        setZero_i[i] = true;
                        setZero_j[j] = true;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (setZero_i[i] || setZero_j[j]) 
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }


        //return true if s1 is a rotation of s2 (page 48)
        public static bool IsRotation(string s1, string s2) 
        {
            if (s1 == null || s2 == null) return false;
            if (s1.Length != s2.Length) return false;

            string s1s1 = s1 + s1;
            return s1s1.Contains(s2);
        }

        
    }
}
