using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.CrackingTough
{
    public class NumbertoEnglishPhrase
    {

        public static void Test()
        {
            Console.WriteLine("240299 = " + ToString(240299));

        }

        public static string ToString(int number) 
        {
            string value = GetBelowThousand(number % 1000);

            if (number >= 1000)
            {
                value = string.Format("{0} thousand, {1}", GetBelowThousand(number / 1000), GetBelowThousand(number % 1000));
            }

            return value;
        }

        private static string GetBelowThousand(int number)
        {
            string value = ToStringBelowHundred(number % 100);

            if (number > 100)
            {
                value = string.Format("{0} hundred and {1}", ToStringUnit(number / 100), value);
            }

            return value;
        }

        private static string ToStringBelowHundred(int number)
        {
            if (number >= 20)
            {
                return ToStringTens(number / 10) + " " + ToStringUnit(number % 10);
            }
            else if (number < 10)
            {
                return ToStringUnit(number);
            }
            else
            {
                switch (number)
                {
                    case 10:
                        return "ten";
                    case 11:
                        return "eleven";
                    case 12:
                        return "twelve";
                    case 13:
                        return "thirteen";
                    case 14:
                        return "fourteen";
                    case 15:
                        return "fifteen";
                    case 16:
                        return "sixteen";
                    case 17:
                        return "seventeen";
                    case 18:
                        return "eighteen";
                    case 19:
                        return "nineteen";
                    default:
                        throw new FormatException();
                }
            }
        }

        private static string ToStringUnit(int unit)
        {
            switch (unit)
            {
                case 0:
                    return "";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new FormatException();
            }
        }

        private static string ToStringTens(int unit)
        {
            switch (unit)
            {
                case 1:
                    return "ten";
                case 2:
                    return "twenty";
                case 3:
                    return "thirty";
                case 4:
                    return "forty";
                case 5:
                    return "fifty";
                case 6:
                    return "sixty";
                case 7:
                    return "seventy";
                case 8:
                    return "eighty";
                case 9:
                    return "ninety";
                default:
                    throw new FormatException();
            }
        }

    }
}
