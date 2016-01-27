using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Strings
{
    public class EditDistance
    {
        public static void Test()
        {
            Console.WriteLine(MinimumEditDistance("Sunday", "Saturday"));
        }

        private static int MinimumEditDistance(string a, string b)
        {
            int[][] cache = new int[a.Length][];
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = new int[b.Length];
            }

            return MinimumEditDistance(a, b, a.Length - 1, b.Length - 1, cache);
        }

        private static int MinimumEditDistance(string str1, string str2, int m, int n, int[][] cache)
        {
            if (cache[m][n] > 0) return cache[m][n];

            int result = 0;

            if (m == 0) result = n;
            else if (n == 0) result = m;
            else if (str1[m] == str2[n])
            {
                result = MinimumEditDistance(str1, str2, m - 1, n - 1, cache);
            }
            else
            {
                int insert = MinimumEditDistance(str1, str2, m, n - 1, cache);
                int delete = MinimumEditDistance(str1, str2, m - 1, n, cache);
                int update = MinimumEditDistance(str1, str2, m - 1, n - 1, cache);

                return 1 + Math.Min(Math.Min(insert, delete), update);
            }

            cache[m][n] = result;
            return result;
        }
    }
}
