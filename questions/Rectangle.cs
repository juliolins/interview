using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class RectangularGrid
    {
        public static void Test()
        {
            long count = new RectangularGrid().countRectangles(3, 3);
        }


        public long countRectangles(int width, int height)
        {
            int count = 0;

            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    if (i != j)
                    {
                        count = count + width + height - i - j;
                    }
                }
            }

            return count;
        }
    }
}
