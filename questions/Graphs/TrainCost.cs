using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{

    //http://www.geeksforgeeks.org/find-the-minimum-cost-to-reach-a-destination-where-every-station-is-connected-in-one-direction/
    public class TrainCost
    {
        public static void Test()
        {
            int INF = -1;

            int[][] cost = new int[][] { 
                new int[] {0, 15, 80, 90},
                new int[] {INF, 0, 40, 50},
                new int[] {INF, INF, 0, 70},
                new int[] {INF, INF, INF, 0}
             };

            Console.WriteLine(FindCost(cost, 0, 3));
        }

        public static int FindCost(int[][] cost, int start, int end)
        {
            if (start == end)
            {
                return 0;
            }

            int minCost = cost[start][end];

            for (int i = start + 1; i < cost.Length; i++)
            {
                int otherCost = cost[start][i] + FindCost(cost, i, end);

                if (otherCost < minCost)
                {
                    minCost = otherCost;
                }
            }

            return minCost;
        }
    }
}
