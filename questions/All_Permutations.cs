using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class All_Permutations
    {
        public static int count = 1;

        public static void Test()
        {
            //PrintAllPermutations(new char[] {'a', 'b', 'c', 'd'});

            Permute(new char[] { 'a', 'b', 'c', 'd' }, 0, 4);
        }


        public static void PrintAllPermutations(char[] word)
        {
            char[] aux = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    aux[j] = word[(j + i) % word.Length];
                }
                Print(aux);
            }
        }

        public static void Print(char[] word)
        {
            //Console.Write("[" + count++ + "] ");
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(word[i]);
            }
            Console.WriteLine();
        }


        public static void Permute(char[] word, int start, int end)
        {
            if (start == end)
            {
                Print(word);
                return;
            }

            for (int i = start; i < end; i++)
            {
                Swap(word, start, i);
                Permute(word, start + 1, end);
                Swap(word, i, start);
            }
        }

        private static void Swap(char[] word, int i, int j)
        {
            char temp = word[i];
            word[i] = word[j];
            word[j] = temp;
        }

    }

    public static class MyExtension
    {
        public static string ToBeautifilString(this char[] word)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            for (int i = 0; i < word.Length; i++)
            {
                builder.Append(word[i]);
                if (i < word.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append("]");

            return builder.ToString();

        }

    }
}
