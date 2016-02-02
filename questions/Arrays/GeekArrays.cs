using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Arrays
{
    public class GeekArrays
    {

        //file:///C:/Julio/Temp/GeeksForGeeks/Stock%20Buy%20Sell%20to%20Maximize%20Profit%20-%20GeeksforGeeks.htm
        //{100, 180, 260, 310, 40, 535, 695}
        public static int MaxGain(int[] stockPrices)
        {
            int maxProfit = int.MinValue;
            int profitSum = 0;

            for (int i = 1; i < stockPrices.Length; i++)
            {
                profitSum += stockPrices[i] - stockPrices[i - 1];
                if (profitSum > maxProfit)
                {
                    maxProfit = profitSum;
                }

                if (profitSum < 0)
                {
                    profitSum = 0;
                }
            }

            return maxProfit;
        }
    }
}
