using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class StringPermutations2
    {

        public static void Test()
        {
            char[] letters = "abc".ToCharArray();

            PrintPermutations(letters);
        }

        public static void PrintPermutations(char[] letters)
        {
            DoPrintPermutations(letters, 0);
        }

        private static void DoPrintPermutations(char[] letters, int start)
        {
            if (start >= letters.Length)
            {
                Print(letters);
                return;
            }

            for (int i = start; i < letters.Length; i++)
            {
                letters.Swap(start, i);

                DoPrintPermutations(letters, start + 1);

                letters.Swap(start, i);
            }

        }

        private static void Print(char[] letters)
        {
            Console.WriteLine(new string(letters));
        }
    }
}
