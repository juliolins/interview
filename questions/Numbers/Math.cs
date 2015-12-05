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
            TestExpo(2, 0);
            TestExpo(2, 1);
            TestExpo(2, 8);
            TestExpo(2, 8);
            TestExpo(2, 9);
            TestExpo(2, 7);

            TestExpo(2, 16);
            TestExpo(2, 18);
        }

        private static void TestExpo(int theBase, int exponent)
        {
            Console.WriteLine(string.Format("E_{0} = {1}", Math.Pow(theBase, exponent), Exponentiate(theBase, exponent)));
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
    }
}
