using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    //http://www.geeksforgeeks.org/count-of-n-digit-numbers-whose-sum-of-digits-equals-to-given-sum/
    public class SumDigits
    {

        public static void Test()
        {
            Check(2, 2);
            Check(2, 5);
            Check(3, 6);
        }

        private static void Check(int n, int sum)
        {
            Console.WriteLine(string.Format("n = {1} & sum = {1}: count = {2}", n, sum, Calculate(n, sum)));
        }

        private static int Calculate(int n, int sum)
        {
            int[][] cache = new int[n + 1][];
            for (int i = 0; i <= n; i++)
			{
                cache[i] = new int[sum + 1];
			    for (int j = 0; j <= sum; j++)
			    {
			        cache[i][j] = -1;
			    }
			}

            int count = 0;

            for (int i = 1; i <= 9; i++)
            {
                if (sum - i >= 0) count += DoCalculate(n - 1, sum - i, cache);
            }

            return count;
        }

        private static int DoCalculate(int n, int sum, int[][] cache)
        {
            if (n == 0)
            {
                return (sum == 0) ? 1 : 0;
            }

            if (cache[n][sum] >= 0)
            {
                return cache[n][sum];
            }

            int count = 0;
            for (int i = 0; i <= 9; i++)
            {
                if (sum - i >= 0)
                {
                    count += DoCalculate(n - 1, sum - i, cache);
                }
            }

            cache[n][sum] = count;

            return count;
        }
    }
}
