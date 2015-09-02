using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    /// <summary>
    /// 2) Given two very large strings, consisting of only digits, multiply the two strings and return the result as a string.
    /// </summary>
    public class BigInt3
    {
        public static void Test()
        {
            Check(12345, 123);
        }


        private static void Check(int a, int b)
        {
            string multiCPU = (a * b).ToString();
            string multi = Multiply(a.ToString(), b.ToString());

            Console.WriteLine("{0} * {1}: {2} = {3} ({4})", a, b, multiCPU, multi, multi.Equals(multiCPU));
        }

        public static string Multiply(string a, string b)
        {
            string multiplier = (a.Length > b.Length) ? b : a;
            string multiplicand = (a.Length > b.Length) ? a : b;

            int[] result = new int[a.Length + b.Length];
            int rest = 0;
            int resultStart = result.Length - 1;
            int resultIndex = 0;

            for (int i = multiplier.Length - 1; i >= 0; i--)
            {
                resultIndex = resultStart--;

                for (int j = multiplicand.Length - 1; j >= 0; j--)
                {
                    int value = GetInt(multiplier[i]) * GetInt(multiplicand[j]) + rest + result[resultIndex];
                    result[resultIndex] = value % 10;
                    rest = value / 10;
                    resultIndex--;
                }

                if (rest > 0)
                {
                    result[resultIndex] += rest;
                    rest = 0;
                }
            }

            //convert to string
            char[] charResult = new char[result.Length - resultIndex - 1];
            for (int i = 0; i < charResult.Length; i++)
            {
                charResult[charResult.Length - i - 1] = GetChar(result[result.Length - i - 1]);
            }

            return new string(charResult);
        }

        private static int GetInt(char ch)
        {
            return ch - '0';
        }

        private static char GetChar(int n)
        {
            return (char) ('0' + n);
        }
    }
}
