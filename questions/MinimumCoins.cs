using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class MinimumCoins
    {

        public static void Test()
        {
            Check(new int[] { 25, 10, 5 }, 30);
            Check(new int[] { 9, 6, 5, 1 }, 11);
        }

        public static void Check(int[] coins, int value)
        {
            Console.WriteLine(string.Format("int[] = {0} | V = {1} | Result = {2}", coins.Print(), value, Count(coins, value)));
        }

        public static int Count(int[] coins, int value)
        {
            if (value == 0)
            {
                return 0;
            }

            int minCoins = int.MaxValue;

            //check every coin recursively
            for (int i = 0; i < coins.Length; i++)
            {
                int newValue = value - coins[i];

                if (newValue >= 0)
                {
                    int count = 1 + Count(coins, newValue);

                    if (count < minCoins)
                    {
                        minCoins = count;
                    }
                }
            }

            return minCoins;
        }



        //public static int CalculateNumer(int[] coins, int value)
        //{
        //    int count = 0;

        //    int coinIndex = 0;

        //    while (value > 0)
        //    {
        //        //not possible to calculate the response
        //        if (coinIndex == coins.Length)
        //        {
        //            return -1;
        //        }



        //    }

        //    return count;
        //}
    }
}
