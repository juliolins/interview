using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    //[Google-Screen] Given a m,n matrix return another matrix that for each
    //element i,j it contains the sum of the original matrix from 0,0 to i,j.

    public class MatrixSum
    {


        public static int[][] CreateSumMatrix(int[][] source)
        {
            int[][] result = new int[source.Length][];
            
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[source[i].Length];
            }

            int sum = 0;

            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < source[i].Length; j++)
                {
                    sum += source[i][j];
                    result[i][j] = sum;
                }
            }

            return result;
        }
    }
}
