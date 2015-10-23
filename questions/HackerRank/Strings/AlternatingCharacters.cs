using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.HackerRank.Strings
{
    //https://www.hackerrank.com/challenges/alternating-characters
    public class AlternatingCharacters
    {
        public static void Test()
        {
            Console.WriteLine(NumberOfDeletions("AAAA"));
            Console.WriteLine(NumberOfDeletions("BBBBB"));
            Console.WriteLine(NumberOfDeletions("ABABABAB"));
            Console.WriteLine(NumberOfDeletions("BABABA"));
            Console.WriteLine(NumberOfDeletions("AAABBB"));
        }

        public static int NumberOfDeletions(string str)
        {
            int total = 0;
            int partial = 0;
            char ch = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    partial++;
                }
                else
                {
                    total += partial;
                    partial = 0;
                    ch = str[i];
                }
            }

            total += partial;

            return total;
        }
    }
}
