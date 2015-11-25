using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Facebook
{
    public class FindSumArray
    {
        public static void Test()
        {
            int[] array = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            Console.WriteLine(IsThereSumN(array, 12, 3));
        }

        /// <summary>
        /// Find if there are two elements in the array add to sum in O(n) 
        /// 
        /// Only works if there are no duplicates.
        /// </summary>
        public static bool IsThereSum(int[] array, int sum)
        {
            var dictionary = new Dictionary<int, bool>();

            for (int i = 0; i < array.Length; i++)
            {
                dictionary.Add(array[i], true);
            }

            for (int i = 0; i < array.Length; i++)
            {
                int diff = sum - array[i];
                if (diff != array[i] && dictionary.ContainsKey(diff))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsThereSumN(int[] array, int sum, int N)
        {
            var dictionary = new Dictionary<int, bool>();

            for (int i = 0; i < array.Length; i++)
            {
                dictionary.Add(array[i], false);
            }

            foreach (var number in dictionary.Keys)
            {
                dictionary.Remove(number);
            }

            return false;
        }

        private static bool IsThereSumThree(int[] array, int sum)
        {
            var dictionary = new Dictionary<int, bool>();

            for (int i = 0; i < array.Length; i++)
            {
                dictionary.Add(array[i], false);
            }

            for (int i = 0; i < array.Length; i++)
            {
                dictionary[array[i]] = true;

                if (IsThereSumTwo(array, sum - array[i], dictionary))
                {
                    return true;
                }

                dictionary[array[i]] = false;
            }

            return false;
        }

        private static bool IsThereSumTwo(int[] array, int sum, Dictionary<int, bool> dictionary)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey(array[i]) && dictionary[array[i]] == true)
                {
                    continue;
                }

                int diff = sum - array[i];
                if (diff != array[i] && dictionary.ContainsKey(diff) && dictionary[diff] == false)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
