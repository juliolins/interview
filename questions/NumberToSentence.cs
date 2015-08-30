using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    class NumberToSentence
    {

        public static void Test()
        {
            Console.WriteLine(GetSentence(999999));
        }

        public static string GetSentence(int number)
        {

            if (number < 1000)
            {
                return GetHundreds(number);
            }
            else
            {
                if (number % 1000 > 0)
                {
                    return GetHundreds(number / 1000) + " thousand and " + GetHundreds(number % 1000);
                }
                else
                {
                    return GetHundreds(number / 1000) + " thousand"; 
                }

            }


        }

        public static string GetHundreds(int number)
        {
            string setence = "";

            if (number % 100 > 0)
            {
                setence = setence + GetDecimal(number % 100);
            }

            if (number % 1000 > 100)
            {
                if (!string.IsNullOrWhiteSpace(setence))
                {
                    setence = " and " + setence;
                }

                setence = GetUnit((number % 1000) / 100) + " hundred"  +setence;
            }

            return setence;
        }


        public static string GetDecimal(int number)
        {
            if (number > 99) throw new Exception("INvalid");

            if (number < 10)
                return GetUnit(number);

            if (number == 10)
            {
                return "ten";
            }
            else if (number == 11)
            {
                return "eleven";
            }
            else if (number == 12)
            {
                return "twelve";
            }
            else if (number == 13)
            {
                return "thirteen";
            }
            else if (number == 14)
            {
                return "fourteen";
            }
            else if (number == 15)
            {
                return "fifteen";
            }
            else if (number == 16)
            {
                return "sexteen";
            }
            else if (number == 17)
            {
                return "seventeen";
            }
            else if (number == 18)
            {
                return "eighteen";
            }
            else if (number == 19)
            {
                return "nineteen";
            }
            else if (number <= 29)
            {
                return "twenty " + GetUnit(number % 10);
            }
            else if (number <= 39)
            {
                return "thirty " + GetUnit(number % 10);
            }
            else if (number <= 49)
            {
                return "forty " + GetUnit(number % 10);
            }
            else if (number <= 59)
            {
                return "fifty " + GetUnit(number % 10);
            }
            else if (number <= 69)
            {
                return "sixty " + GetUnit(number % 10);
            }
            else if (number <= 79)
            {
                return "sevent " + GetUnit(number % 10);
            }
            else if (number <= 89)
            {
                return "eighty " + GetUnit(number % 10);
            }
            else if (number <= 99)
            {
                return "ninety " + GetUnit(number % 10);
            }

            throw new Exception("INvalid");
        }

        public static string GetUnit(int number)
        {
            switch (number)
            {
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

                case 0:
                    return "";

                default:
                    throw new Exception("INvalid");
            }

        }

    }
}
