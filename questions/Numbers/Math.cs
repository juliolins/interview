using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Numbers
{
    public class TheMath
    {

        public static void Test()
        {
            //TestExpo(2, 0);
            //TestExpo(2, 1);
            //TestExpo(2, 8);
            //TestExpo(2, 8);
            //TestExpo(2, 9);
            //TestExpo(2, 7);

            //TestExpo(2, 16);
            //TestExpo(2, 18);

            //TestExpoD(2, 3.72);

            //TestSqrt(4);
            //TestSqrt(2.7);
            //TestSqrt(16);
            //TestSqrt(5);
            //TestExpoD(2.7, 1.23456);

            TestParse("1234");
        }

        private static void TestExpo(int theBase, int exponent)
        {
            Console.WriteLine(string.Format("E_{0} = {1}", Math.Pow(theBase, exponent), Exponentiate(theBase, exponent)));
        }

        private static void TestExpoD(double theBase, double exponent)
        {
            const double precision = 0.000000000000001;
            Console.WriteLine("M "+ Math.Pow(theBase, exponent));
            Console.WriteLine("J " + Exponentiate(theBase, exponent, precision));
        }

        private static void TestParse(string number)
        {
            Console.WriteLine("M " + double.Parse(number));
            Console.WriteLine("J " + ParseDouble(number));
        }


        private static void TestSqrt(double number)
        {
            const double precision = 0.00000000000001;
            Console.WriteLine("MS " + Math.Sqrt(number));
            Console.WriteLine("JS " + sqrt2(number, precision));
        }

        public static void IntegerDivision(int numerator, int denominator, ref int quotient, ref int rest)
        {
            while (numerator > denominator)
            {
                quotient++;
                numerator -= denominator;
            }

            rest = numerator;
        }

        public static int Exponentiate(int theBase, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }
            else if (exponent == 1)
            {
                return theBase;
            }
            else if (exponent % 2 == 0)
            {
                return Exponentiate(theBase * theBase, exponent / 2);
            }
            else
            {
                return theBase * Exponentiate(theBase * theBase, (exponent - 1) / 2);
            }
        }

        public static double Exponentiate(double theBase, double exponent, double precision)
        {
            if (exponent == 0)
            {
                return 1;
            }
            else if (exponent == 1)
            {
                return theBase;
            }
            else if (exponent > 1)
            {
                if (((int)exponent) % 2 == 0)
                {
                    return Exponentiate(theBase * theBase, exponent / 2, precision);
                }
                else
                {
                    return theBase * Exponentiate(theBase * theBase, (exponent - 1) / 2, precision);
                }
            }
            else //we have only the fraction part
            {
                const double sqrtPrecision = 0.0000000000000001;
                double sqrtPoint = 0.5;
                double baseValue = 1;
                double sqrtBase = sqrt2(theBase, sqrtPrecision);

                //keep going until the exponent is small enough
                while (exponent > precision)
                {
                    if (exponent >= sqrtPoint)
                    {
                        exponent -= sqrtPoint;
                        baseValue *= sqrtBase;
                    }

                    sqrtPoint /= 2;
                    sqrtBase = sqrt2(sqrtBase, sqrtPrecision);
                }

                return baseValue;
            }
        }

        public static double sqrt(double number, double precision)
        {
            if (number > 1)
            {
                return sqrt(number, 1, number, precision);
            }
            else
            {
                return sqrt(number, precision, number, precision);
            }
        }

        private static double sqrt(double number, double low, double high, double precision)
        {
            double middle = (low + high) / 2;
            double square = middle * middle;

            while (Math.Abs(number - square) > precision)
            {
                if (square > number)
                {
                    high = middle;
                }
                else
                {
                    low = middle;
                }

                middle = (low + high) / 2;
                square = middle * middle;
            }

            return middle;
        }

        //https://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Babylonian_method
        public static double sqrt2(double number, double precision)
        {
            double x = (number + 1) / 2;
            
            while ((precision *= 100) < 1)
            {
                x = (x + number / x) / 2;
            }

            return x;
        }

        public static double ParseDouble(string number)
        {
            int dotIndex = GetDotIndex(number);

            //handle integral part
            int integralStart = 0;
            int integralEnd = (dotIndex > 0) ? dotIndex - 1 : number.Length - 1;
            double value = ParseLong(number, integralStart, integralEnd);

            //if there's a fractional part
            if (dotIndex > 0)
            {
                int factionalExponent = number.Length - dotIndex - 1;
                double faction = ParseLong(number, dotIndex + 1, number.Length - 1);
                while (factionalExponent-- > 0)
                {
                    faction /= 10;
                }

                value += faction;
            }

            return value;
        }

        private static int GetDotIndex(string number)
        {
            int dotIndex = -1;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '.')
                {
                    if (dotIndex < 0)
                    {
                        dotIndex = i;
                    }
                    else
                    {
                        throw new FormatException("Multiple dots");
                    }
                }
            }

            return dotIndex;
        }

        private static long ParseLong(string number, int index, int endIndex)
        {
            long value = 0;
            while (index <= endIndex)
            {
                char ch = number[index];
                
                if (ch < '0' || ch > '9')
                {
                    throw new FormatException();
                }

                value *= 10;
                value += ch - '0';
                index++;
            }

            return value;
        }
    }
}
