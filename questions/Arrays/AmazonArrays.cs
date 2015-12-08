using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Arrays
{
    public class AmazonArrays
    {
        public static void Test()
        {
            int[] towers = new int[] {5,3,7,2,6,4,5,9,1,2};
            Console.WriteLine(Collect(towers));
        }

        //http://stackoverflow.com/questions/24414700/amazon-water-collected-between-towers
        public static int Collect(int[] towers)
        {
            int[] maxRight = new int[towers.Length];
            int[] maxLeft = new int[towers.Length];

            //scan from from right to left to determine max to the right
            int max = towers[towers.Length - 1];
            for (int i = maxRight.Length - 2; i >= 0; i--)
            {
                if (max < towers[i + 1])
                {
                    max = towers[i + 1];
                }

                maxRight[i] = max;
            }

            //scan from left to right for max left
            max = towers[0];
            for (int i = 1; i < towers.Length; i++)
            {
                if (max < towers[i - 1])
                {
                    max = towers[i - 1];
                }

                maxLeft[i] = max;
            }

            //final interation through the array
            int totalWater = 0;
            for (int i = 1; i < towers.Length - 1; i++)
            {
                int localWater = Math.Min(maxRight[i], maxLeft[i]) - towers[i];
                if (localWater > 0)
                {
                    totalWater += localWater;
                }
            }

            return totalWater;
        }
    }
}
