using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    //http://www.geeksforgeeks.org/count-distinct-elements-in-every-window-of-size-k/
    public class DistincElementsWindow
    {

        public static void Test()
        {
            var result = Count(new int[] { 1, 2, 1, 3, 4, 2, 3 }, 4);
            result.PrintToConsole();
        }

        public static int[] Count(int[] array, int k)
        {
            int[] results = new int[array.Length - k + 1];
            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            int distinctCount = 0;

            //initial window, add numbers and keep track 
            for (int i = 0; i < k; i++)
            {
                if (Add(numberCount, array[i]) == 1)
                {
                    distinctCount++;
                }
            }
            
            //first result
            results[0] = distinctCount;

            //now continue removing one number and adding a new one (extremes of the window)
            for (int i = k; i < array.Length; i++)
            {
                //remove element
                if (Remove(numberCount, array[i - k]) == 0)
                {
                    //removed the last duplicate
                    distinctCount--;
                }

                //add new number
                if (Add(numberCount, array[i]) == 1)
                {
                    distinctCount++;
                }

                results[i - k + 1] = distinctCount;
            }

            return results;
        }

        private static int Add(Dictionary<int, int> numberCount, int number)
        {
            if (numberCount.ContainsKey(number))
            {
                return (numberCount[number] = numberCount[number] + 1);
            }
            else
            {
                numberCount.Add(number, 1);
                return 1;
            }
        }

        private static int Remove(Dictionary<int, int> numberCount, int number)
        {
            return (numberCount[number] = numberCount[number] - 1);
        }
    }
}
