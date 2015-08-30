using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BinarySearch
    {

        public static void TestBS()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            Console.WriteLine("True = " + IsPresent(20, array));
        }

        public static bool IsPresent_0(int x, int[] array)
        {
            int position = 0;
            int range = array.Length;

            while (range > 0)
            {
                range = range / 2;
                int middle = position + range;

                //x is on left
                if (array[middle] > x)
                {
                    //position doesnt change
                }
                //x is on the right
                else if (array[middle] < x)
                {
                    position = middle;
                }
                else
                {
                    //we found it
                    return true;
                }
            }



            return false;
        }


        public static bool IsPresent(int x, int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                //x is on left
                if (array[middle] > x)
                {
                    right = middle - 1;
                }
                //x is on the right
                else if (array[middle] < x)
                {
                    left = middle + 1;
                }
                else
                {
                    //we found it
                    return true;
                }
            }



            return false;
        }

    }
}
