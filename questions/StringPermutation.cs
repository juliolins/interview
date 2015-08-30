using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class StringPermutation
    {
        public static void Test()
        {
            char[] word = "abc".ToCharArray();
            PrintPermutations(word);
        }


        public static void PrintPermutations(char[] word)
        {
            DoPrintPermutations(word, 0);
        }

        public static void DoPrintPermutations(char[] word, int startIndex)
        {
            if (startIndex >= word.Length - 1)
            {
                Console.WriteLine(word.Print());
                return;
            }

            for (int i = startIndex; i < word.Length; i++)
            {
                word.Swap(startIndex, i);
                DoPrintPermutations(word, startIndex + 1);
                word.Swap(startIndex, i);
            }
        }    
    }

    public static class SwapExtension
    {

        public static void Swap<T>(this T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
