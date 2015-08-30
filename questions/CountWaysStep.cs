using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class CountWaysStep
    {

        public static void Test()
        {
            DateTime start = DateTime.Now;
            int[] map = new int[34];

            //for (int i = 0; i < map.Length; i++)
            //{
                //map[i] = -1;
            //}

            Console.WriteLine("Count(33) = " + CountWays(33, map));
            DateTime end = DateTime.Now;

            Console.WriteLine("Seconds: " + (end - start).TotalSeconds);
        }


        public static int CountWays(int n, int[] map)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else if (map[n] > 0)
            {
                return map[n];
            } 
            else {
                map[n] = CountWays(n - 1, map) + CountWays(n - 2, map) + CountWays(n - 3, map);
                return map[n];
            }
        }
    }
}
