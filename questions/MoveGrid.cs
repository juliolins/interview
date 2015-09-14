using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{

    //http://www.geeksforgeeks.org/minimum-positive-points-to-reach-destination/
    public class PointGrid
    {
        
        public static void Test()
        {
            int[][] points = new int[][]{ 
                        new int[] {-2, -3,   3}, 
                        new int[] {-7, -10,  1}, 
                        new int[] {10,  30, -5}
                      };

            Console.WriteLine(MinPointsInteractive(points));
        }


        public static int MinPointsInteractive(int[][] points)
        {
            int m = points.Length;
            int n = points[0].Length;

            int[,] dp = new int[m,n];

            //base case
            dp[m - 1, n - 1] = (points[m - 1][n - 1] > 0) ? 1 : Math.Abs(points[m - 1][n - 1]) + 1;

            //guys without all neighbors
            for (int i = n - 2; i >= 0; i--)
            {
                dp[i, n - 1] = Math.Max(dp[i + 1, n - 1] - points[i][n - 1], 1);
            }

            for (int j = n - 2; j >= 0; j--)
            {
                dp[m - 1, j] = Math.Max(dp[m - 1, j + 1] - points[m - 1][j], 1);
            }

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    int minPath = Math.Min(dp[i + 1, j], dp[i, j + 1]);
                    dp[i, j] = Math.Max(minPath - points[i][j], 1);
                }
            }

            return dp[0, 0];
        }


        public static int MinPoints(int[][] points)
        {
            return Math.Abs(MinPoints(points, 0, 0, 0, 0)) + 1; //plus one we're always positive           
        }

        //each path returns the gratest negative plus any additional balance required at the end
        public static int MinPoints(int[][] points, int x, int y, int sum, int maxNegative)
        {
            sum += points[x][y];

            if (sum < maxNegative)
            {
                maxNegative = sum;
            }

            if (x == points.Length - 1 && y == points[0].Length - 1)
            {
                //in the last position, if sum is still negative, need to add to maxNegative 
                //(in subtract so we still remain positive)
                if (sum < 0 && sum != maxNegative)
                {
                    maxNegative += sum;
                }

                return maxNegative;
            }
            else if (x < points.Length - 1 && y < points[0].Length - 1)
            {
                return Math.Max(MinPoints(points, x + 1, y, sum, maxNegative), MinPoints(points, x, y + 1, sum, maxNegative));
            }
            else if (x == points.Length - 1)
            {
                return MinPoints(points, x, y + 1, sum, maxNegative);
            }
            else //(y == points[0].Length - 1)
            {
                return MinPoints(points, x + 1, y, sum, maxNegative);
            }
        }

        //each path returns the gratest negative
        //less negative wins
        //public static int MinPoints0(int[][] points, int x, int y)
        //{
        //    if (x == points.Length - 1 && y == points[0].Length - 1)
        //    {
        //        return points[x][y];
        //    }
        //    else if (x < points.Length - 1 && y < points[0].Length - 1)
        //    {
        //        return Math.Max(points[x][y] + MinPoints(points, x + 1, y), points[x][y] + MinPoints(points, x, y + 1));
        //    }
        //    else if (x == points.Length - 1)
        //    {
        //        return points[x][y] + MinPoints(points, x, y + 1);
        //    }
        //    else //(y == points[0].Length - 1)
        //    {
        //        return points[x][y] + MinPoints(points, x + 1, y);
        //    }           
        //}

    }





    public class MoveGrid
    {
        public static void Test()
        {
            int[][] grid = new int[][] 
            {
                new int[] {1, 0, 1, 0},
                new int[] {1, 1, 1, 0},
                new int[] {0, 0, 1, 0},
                new int[] {0, 0, 1, 1}
            };

            Console.WriteLine(CanMove(grid));
        }

        public static bool CanMove(int[][] grid)
        {
            return (CanMove(grid, 0, 0)); 
        }

        private static bool CanMove(int[][] grid, int x, int y)
        {
            //return true if reached the end and the cell is positive
            if (x == grid.Length - 1 && y == grid[0].Length - 1)
            {
                return grid[x][y] > 0;
            }

            //if this cell is false, return false
            if (grid[x][y] <= 0)
            {
                return false;
            }

            //navigate right and test path
            if (y < grid[0].Length - 1)
            {
                if (CanMove(grid, x, y + 1)) return true;
            }

            //also check down
            if (x < grid.Length - 1)
            {
                if (CanMove(grid, x + 1, y)) return true;
            }

            //dead end here
            return false;
        }
    }
}
