using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    /// <summary>
    /// Given a string, move all even positioned elements to end of string. 
    /// While moving elements, keep the relative order of all even positioned 
    /// and odd positioned elements same. For example, if the given string is 
    /// “a1b2c3d4e5f6g7h8i9j1k2l3m4″, convert it to “abcdefghijklm1234567891234″ 
    /// in-place and in O(n) time complexity.
    /// </summary>
    public class StringTransformation
    {

        public static void Test()
        {

            string theString = "a1b2c3d4e5f6g7h8i9j1k2l3m4";

            Console.WriteLine(theString);
            char[] chars = theString.ToCharArray();
            Transform2(chars);
            Console.WriteLine(new string(chars));

            Console.WriteLine(chars.Length);
            Console.WriteLine(count);
        }

        public static int count = 0;

        public static void Transform2(char[] theString)
        {           
            for (int i = 1; i < theString.Length / 2; i++)
            {
                for (int j = i; j < theString.Length - i; j = j + 2)
                {
                    count++;
                    Swap(theString, j, j + 1);
                }
            }
        }

        public static void Transform(char[] theString)
        {
            int right = theString.Length - 1;
            int left = theString.Length - 2;

            while (left >= 0)
            {
                if (IsNumber(theString[left]) && IsLetter(theString[right]))
                {
                    Swap(theString, left, right);
                    right--;
                }

                left--;
            }
        }

        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static bool IsNumber(char ch)
        {
            return '0' <= ch && ch <= '9';
        }

        public static bool IsLetter(char ch)
        {
            return 'a' <= ch && ch <= 'z';
        }


    }
}
