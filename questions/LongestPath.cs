using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    //http://www.geeksforgeeks.org/find-length-of-the-longest-consecutive-path-in-a-character-matrix/
    public class LongestPath
    {

        public static void Test()
        {
            char[][] matrix = new char[][] 
                        {
                            new char[] {'a', 'c', 'd'},
                            new char[] {'h', 'b', 'e'},
                            new char[] {'i', 'g', 'f'}
                        };

            Console.WriteLine(Count(matrix, 2, 0));
        }

        public static int Count(char[][] matrix, int i, int j)
        {
            return Count(matrix, i, j, matrix[i][j]);
        }

        private static int Count(char[][] matrix, int i, int j, char next)
        {
            if (i < 0 || i >= matrix[0].Length || j < 0 || j >= matrix[0].Length)
            {
                return 0;
            }

            if (matrix[i][j] != next)
            {
                return 0;
            }

            //update next
            next = (char) (next + 1);

            int longest = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    //skip self
                    if (x == 0 && y == 0) continue;

                    int path = 1 + Count(matrix, i + x, j + y, next);

                    if (path > longest)
                    {
                        longest = path;
                    }
                }
            }

            return longest;
        }
    }
}
