using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    class QuickSort
    {


        public static int Partition(int[] array, int start, int end)
        {
            int i = start + 1, j = end;
            int element = array[start];

            while (i < j)
            {

                while (array[i] < element)
                {
                    i++;
                }

                while (array[j] >= element)
                {
                    j--;
                }

                array.Swap(i, j);
            }

            array.Swap(start, j);

            return j;
        }
    }
}
