using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.BitManipulation
{
    public class TestBits
    {
        public static void Test()
        {
            int x = 100000000;
            string xstr = x.ToBinaryString();
            Console.WriteLine(x + " = " + xstr + " = " + xstr.ToIntFromBinary());


            string n = "10000000000";
            string m = "10101";

            Console.WriteLine(n + " join " + m + " = " + CrackingBits.Join(n, m, 2, 6));
        }
    }


    public class CrackingBits
    {
        public static string Join(string str1, string str2, int i, int j)
        {
            int n = str1.ToIntFromBinary();
            int m = str2.ToIntFromBinary();

            return Join(n, m, i, j).ToBinaryString();
        }

        public static int Join(int n, int m, int i, int j)
        {
            //clean m
            int allOnes = ~0;
            allOnes = allOnes >> (j - i + 1);
            m = m & allOnes;

            //prepare m for join
            m <<= i;

            allOnes = ~0;
            allOnes >>= (j - i + 1);
            allOnes <<= i;

            //prapare n for join
            n = n | allOnes;

            return (n & m);
        }

    }

    public static class BitExtensions
    {
        public static int ToIntFromBinary(this string str)
        {
            int number = 0;
            int power = 0;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '1') number += (int) Math.Pow(2, power);
                power++;
            }

            return number;
        }


        public static string ToBinaryString(this int number)
        {
            char[] str = new char[ (int) Math.Ceiling(Math.Log(number, 2))];
            int index = str.Length;

            while (number > 0)
            {
                str[--index] = (char) ((number % 2) + '0');
                number >>= 1;
            }

            return new string(str, index, str.Length - index);
        }
    }
}
