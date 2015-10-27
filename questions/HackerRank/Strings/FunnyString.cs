using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.HackerRank
{
    //https://www.hackerrank.com/challenges/funny-string
    public class FunnyString
    {

        public static void Test()
        {
            Console.WriteLine(IsFunny("acxz"));
            Console.WriteLine(IsFunny("bcxz"));
        }

        public static bool IsFunny(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (Math.Abs(str[i] - str[i + 1]) != Math.Abs(str[str.Length - 1 - i] - str[str.Length - 2 - i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
