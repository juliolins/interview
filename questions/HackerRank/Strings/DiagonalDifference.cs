using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.HackerRank
{
    //https://www.hackerrank.com/challenges/diagonal-difference
    public class DiagonalDifference
    {

        public int Difference(int[][] matrix, int n)
        {
            int downSum = 0;
            int upSum = 0;

            for (int i = 0; i < n; i++)
            {
                downSum += matrix[i][i];
                upSum += matrix[i][n - 1 - i];
            }

            return Math.Abs(downSum - upSum);
        }
    }
}
