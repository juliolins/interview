using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class MaximumProductSubarray
    {
        public static void Test()
        {
            int[] array = new int[] { -2, -3, 0, -2, -40 };

            Console.WriteLine(MaxProduct(array));
        }

        public static int MaxProduct(int[] array)
        {
            int max = 0;
            int product = 1;

            for (int i = 0; i < array.Length; i++)
            {
                product *= array[i];

                if (product == 0)
                {
                    product = 1;
                }

                if (product > max)
                {
                    max = product;
                }

            }

            return max;
        }


    }
}
