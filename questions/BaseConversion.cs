using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BaseConversion
    {

        public static void Test()
        {
            //List<int> digits = GetDigits(9);

            //foreach (int item in digits)
            //{
            //    Console.Write(item + " ");
            //}

            Console.WriteLine(10%3);
        }

        public static int GetMax(int theBase) 
        {
            int result = 0;
            int multiplier = (theBase <= 10) ? 10 : 100;

            for (int i = 0; i < 3; i++)
            {
                result *= multiplier;
                result += (theBase - 1);
            }

            return result;
        }

        public static int GetDigitsSum(int number, int theBase) 
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        public static bool IsDigitSumMultiple(int number, int digit, int theBase)
        {
            int sum = GetDigitsSum(number, theBase);

            return sum % digit == 0;
        }

        public static List<int> GetDigits(int theBase)
        {
            bool[] isNumberBad = new bool[theBase];
            int max = GetMax(theBase);

            for (int i = 1; i < max; i++)
            {
                for (int j = 1; j < theBase; j++)
                {
                    if (i % j == 0)
                    {
                        isNumberBad[j] = isNumberBad[j] || !IsDigitSumMultiple(i, j, theBase);
                    }
                }
            }

            List<int> digits = new List<int>();

            for (int i = 0; i < theBase; i++)
            {
                if (!isNumberBad[i]) digits.Add(i);
            }

            return digits;
        }
    }
}
