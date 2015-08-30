using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class WordsFromNumbers
    {


        public static void Test()
        {
            char[] numbers = "2345".ToCharArray();
            char[] word = new char[numbers.Length];

            Generate(numbers, word, 0);
            Console.WriteLine("Count = " + count);
        }

        public static char[][] letters = new char[][] { new char[] { }, new char[] { }, 
            new char[] { 'a', 'b', 'c' }, new char[] { 'd', 'e', 'f' }, new char[] { 'g', 'h', 'i' },
            new char[] { 'j', 'k', 'l' }, new char[] { 'm', 'n', 'o' }, new char[] { 'p', 'q', 'r', 's' },
            new char[] { 't', 'u', 'v' }, new char[] { 'w', 'x', 'y', 'z' }
        };

        private static int count = 0;

        public static void Generate(char[] numbers, char[] word, int start)
        {
            if (start == numbers.Length)
            {
                Console.WriteLine(word);
                count++;
                return;
            }

            int index = int.Parse(numbers[start] + "");

            for (int i = 0; i < letters[index].Length; i++)
            {
                word[start] = letters[index][i];
                Generate(numbers, word, start + 1);
            }
        }
    }
}
