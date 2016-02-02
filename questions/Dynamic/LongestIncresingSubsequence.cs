using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Dynamic
{
    public class LongestIncresingSubsequence
    {
        private static int Calls = 0;

        public static void Test()
        {
            //int[] a = new int[] { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            //Console.WriteLine(CountSequence2(a));

            //Console.WriteLine(Calls);

            Console.WriteLine(CountWays(6, new int[7]));
            Console.WriteLine(CountWays2(6));
        }

        public static int CountSequence(int[] array)
        {
            return CountSequence(array, 0, -1, new Dictionary<string, int>());
        }

        public static int CountSequence(int[] array, int index, int last, Dictionary<string, int> cache)
        {
            Calls++;
            int result = 0;
            string key = string.Format("{0}_{1}", index, last);

            if (index == array.Length)
            {
                return 0;
            }

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (array[index] > last)
            {
                int with = 1 + CountSequence(array, index + 1, array[index], cache);
                int without = CountSequence(array, index + 1, last, cache);
                result = Math.Max(with, without);
            }
            else
            {
                result = CountSequence(array, index + 1, last, cache);
            }

            cache.Add(key, result);
            return result;
        }


        private static int CeilIndex(int[] sequences, int left, int right, int value)
        {
            while (left < right)
            {
                int middle = (left + right) / 2;

                if (middle <= value)
                {
                    right = middle;
                }
                else
                {
                    left = middle;
                }
            }

            return right;
        }

        public static int CountSequence2(int[] array)
        {
            int[] sequences = new int[array.Length];
            int last = 0;

            sequences[last++] = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < sequences[0])
                {
                    sequences[0] = array[i];
                }
                else if (array[i] > sequences[last - 1])
                {
                    sequences[last++] = array[i];
                }
                else
                {
                    int index = CeilIndex(array, 0, last - 1, array[i]);
                    sequences[index] = array[i];
                }
            }

            return last;
        }

        public static int CountWays(int distance, int[] cache)
        {
            if (distance == 0)
            {
                return 1;
            }

            if (cache[distance] > 0)
            {
                return cache[distance];
            }

            int result = 0;
            if (distance >= 3)
            {
                result += CountWays(distance - 3, cache);
            }

            if (distance >= 2)
            {
                result += CountWays(distance - 2, cache);
            }

            if (distance >= 1)
            {
                result += CountWays(distance - 1, cache);
            }

            cache[distance] = result;
            return result;
        }

        public static int CountWays2(int distance)
        {
            if (distance <= 2) return distance;

            int nm3 = 1;
            int nm2 = 1;
            int nm1 = 2;
            int count = 0;
            for (int i = 3; i <= distance; i++)
            {
                count = nm3 + nm2 + nm1;
                nm3 = nm2;
                nm2 = nm1;
                nm1 = count;
            }

            return count;
        }
    }
}
