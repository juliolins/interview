using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class LIS
    {
        public static void Test()
        {
            int[] array = new int[] { 1, 9, 3, 8, 11, 4, 5, 6, 4, 19, 7, 1, 7 };

            FindLis(array);
        }

        public static void FindLis(int[] array)
        {
            //helper stack
            List<int> list = new List<int>();

            //LIS array?
            int[] lis = new int[array.Length];

            //add first index to the stack
            list.Add(0);

            //from the second element on
            for (int i = 1; i < array.Length; i++)
            {
                // If next element a[i] is greater than last element of current longest subsequence a[stack.Peek()], 
                //just push it at back of "b" and continue
                if (array[list.Last()] < array[i])
                {
                    //save the index of the smaller element of this one in a separate array
                    lis[i] = list.Last();

                    //save the current as the largest
                    list.Add(i);

                    continue;
                }

                // Binary search to find the smallest element referenced by b which is just bigger than a[i]
                // Note : Binary search is performed on b (and not a). Size of b is always <=k and hence contributes O(log k) to complexity.    
                int low = 0;
                int high = list.Count - 1;
                while (low < high)
                {
                    int middle = (low + high) / 2;

                    if (array[list[middle]] < array[i])
                    {
                        low = middle + 1;
                    }
                    else
                    {
                        high = middle;
                    }
                }

                // Update b if new value is smaller then previously referenced value 
                if (array[i] < array[list[low]])
                {
                    if (low > 0) lis[i] = list[low - 1];
                    list[low] = i;
                }

                //
                for (low = list.Count, high = list.Last(); ;low--, high = lis[high])
                {
                    if (low == list.Count)
                    {
                        list.Add(high);
                    }
                    else
                    {
                        list[low] = high;
                    }
                }

            }

            //DONE! print sequence
            for (int i = 0; i < lis.Length; i++)
            {
                Console.Write("%d ", lis[i]);
            }
        }
    }
}
