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

            //int[] a = new int[] { 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            //a.PrintToConsole();
            //int x = 6;
            //Console.WriteLine("x = " + x + " & i = " + CrackingSorting.BinarySearchRotated(a, x));

            //int[] a = new int[] { 1, -1, 3, -1, -1, 6, 7, -1, 9 };
            //a.PrintToConsole();
            //int x = 3;
            //Console.WriteLine("x = " + x + " & i = " + CrackingSorting.BinarySearchEmptySlots(a, x));

            int[][] matrix = new int[][] 
            {
                new int[] {01, 03, 05, 07},
                new int[] {02, 09, 11, 13},
                new int[] {04, 10, 16, 17},
                new int[] {06, 12, 18, 19},
                new int[] {08, 14, 20, 21},
            };

            Console.WriteLine(CrackingSorting.Contains(matrix, 12));
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

        public static int BinarySearchEmptySlots(int[] array, int value)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (array[middle] < 0)
                {
                    if ((middle = FindNewMiddle(array, left, right, middle)) == -1)
                    {
                        return -1;
                    }                    
                }

                if (value == array[middle])
                {
                    return middle;
                }
                else if (value < array[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        private static int FindNewMiddle(int[] array, int left, int right, int middle)
        {
            int padding = 1;

            while (padding <= (right - left + 1) / 2)
            {
                int leftCheck = middle - padding;
                int rightCheck = middle + padding;

                if (leftCheck >= left && array[leftCheck] > 0)
                {
                    return leftCheck;
                }
                else if (rightCheck <= right && array[rightCheck] > 0)
                {
                    return rightCheck;
                }

                padding++;
            }

            return -1;
        }


        public static bool Contains(int[][] matrix, int value)
        {
            int i = 0;
            int j = matrix[0].Length - 1;

            while (i < matrix.Length & j >= 0)
            {
                Console.WriteLine(matrix[i][j]);

                if (value == matrix[i][j])
                {
                    return true;
                }
                else if (value < matrix[i][j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return false;
        }

        public static int MaxTower(Person[] persons)
        {
            if (persons.Length == 0) return 0;
            Array.Sort(persons);

            return 1 + GrabPeople(persons, 2, 1, persons[0]);
        }

        private static int GrabPeople(Person[] persons, int lineSize, int startIndex, Person lastPerson)
        {
            int count = 0;
            while (count <= lineSize && startIndex < persons.Length && lastPerson.CompareTo(persons[startIndex + count]) < 0)
            {
                lastPerson = persons[startIndex + count];
                count++;
            }

            if (count == lineSize)
            {
                return 1 + GrabPeople(persons, lineSize + 1, startIndex + count, lastPerson);
            }
            else
            {
                return 0;
            }            
        }

        public class Person : IComparable
        {
            public int Height { get; set; }
            public int Weight { get; set; }

            public int CompareTo(object obj)
            {
                Person person = obj as Person;
                if (person == null) throw new NotSupportedException();

                if (this.Height < person.Height && this.Weight < person.Weight)
                {
                    return -1;
                }
                else if (this.Height > person.Height && this.Weight > person.Weight)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
