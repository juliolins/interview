using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class DigitsDifference
    {
        public static void Test()
        {
            Check(2);
            Check(3);
        }

        private static void Check(int n)
        {
            Console.WriteLine(string.Format("n = {0}: {1}", n, Count(n)));
        }

        public static int Count(int n)
        {
            //number of odd and event digits
            int oddDigits = n / 2;
            int evenDigits = (n % 2 == 0) ? n/2 : n/2 + 1;

            //catch to save the sum of digits
            int[] cache = new int[(int)Math.Pow(10, evenDigits)];

            //each set of numbers vary independently from zero to biggest numer with n/2 digits
            int maxOdd = (int) Math.Pow(10, oddDigits) - 1;
            int maxEven = (int) Math.Pow(10, evenDigits) - 1;

            int resultCount = 0;

            //check each odd-digit number against all possible even-digit numbers
            //visualize this as an odometer of a car in which the we vary 1 digit in a odd position
            //and then compare to vary all digit variations in the even positions 
            for (int i = 0; i <= maxOdd; i++)
            {
                for (int j = (int) Math.Pow(10, n - 2); j <= maxEven; j++)
                {
                    if (GetSum(cache, j) - GetSum(cache, i) == 1)
                    {
                        resultCount++;
                    }
                }
            }

            return resultCount;
        }

        /// <summary>
        /// Calculates the sum of the digits of a number using a cache
        /// </summary>
        private static int GetSum(int[] cache, int number)
        {
            if (number == 0)
            {
                return 0;
            }

            if (cache[number] != 0)
            {
                return cache[number];
            }

            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            cache[number] = sum;
            return sum;
        }
    }
}
