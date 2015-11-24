using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Facebook
{
    public class GeeksForGeeks
    {
        public static void Test()
        {
            char[] encoding = "0123456789ABCDEF".ToCharArray();

            Console.WriteLine(ConvertToBase(encoding, 435, 16));

            var results = ConvertNumbersToBaseRec(encoding, 50, 16);
            results.PrintToConsole();
        }


        private static string ConvertToBase(char[] encoding, int number, int theBase)
        {
            char[] converted = new char[(int) Math.Ceiling(Math.Log(number, theBase))];
            int index = converted.Length - 1;

            while (number > 0)
            {
                converted[index--] = encoding[number % theBase];
                number /= theBase;
            }

            return new string(converted);
        }
        private static string[] ConvertNumbersToBaseRec(char[] encoding, int n, int theBase)
        {
            string[] results = new string[n + 1];

            for (int i = 0; i <= n; i++)
            {
                results[i] = ConvertToBaseRec(encoding, i, theBase, results);
            }

            return results;
        }

        private static string ConvertToBaseRec(char[] encoding, int number, int theBase, string[] results)
        {
            if (results[number] != null) 
                return results[number];

            string result = null;
            if (number < theBase) result = encoding[number].ToString();
            else result = ConvertToBaseRec(encoding, number / theBase,  theBase, results) + encoding[number % theBase].ToString();

            results[number] = result;
            return result;
        }
    }
}
