using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class BinarySearch2
    {
        public static void Test()
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < array.Length; i++)
            {
                if (i != Search(array, i))
                {
                    throw new Exception();
                }
            }
        }


        public static int Search(int[] array, int value)
        {
            int start = 0;
            int end = array.Length - 1;
            

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (array[middle] < value)
                {
                    start = middle + 1;
                } 
                else if (array[middle] > value)
                {
                    end = middle - 1;
                } 
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}
