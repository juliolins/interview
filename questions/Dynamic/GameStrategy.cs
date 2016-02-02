using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Dynamic
{
    public class GameStrategy
    {
        private static int CallCount = 0;

        public static void Test()
        {
            Console.WriteLine(Maximum(new int[] { 8, 15, 3, 7}));
            Console.WriteLine("Calls: " + CallCount);
        }

        public static int Maximum(int[] numbers)
        {
            return Maximum(numbers, 0, numbers.Length - 1, false, new Dictionary<string, int>());
        }

        //http://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/
        // 5, 3, 7, 10 : The user collects maximum value as 15(10 + 5)
        // 8, 15, 3, 7 : The user collects maximum value as 22(7 + 15)
        public static int Maximum(int[] numbers, int start, int end, bool isOponent, Dictionary<string, int> cache)
        {
            CallCount++;
            string key = string.Format("{0}{1}", start, end);

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            int result = 0;
            if (start > end)
            {
                return 0;
            }
            else if (start == end)
            {
                result = isOponent ? 0 : numbers[start];
            }
            else 
            {
                //select fist
                int first = (isOponent ? 0 : numbers[start]) + Maximum(numbers, start + 1, end, !isOponent, cache);
                int last = (isOponent ? 0 : numbers[end]) + Maximum(numbers, start, end - 1, !isOponent, cache);

                result = isOponent ? Math.Min(first, last) : Math.Max(first, last);
            }

            cache[key] = result;
            return result;
        }
    }
}
