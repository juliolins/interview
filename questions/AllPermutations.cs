using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class AllPermutations2
    {
        public static void Test()
        {
            char[] word = "abc".ToCharArray();
            var list = Permute(word);

            list.PrintToConsole();
        }


        public static IEnumerable<string> Permute(char[] word)
        {
            List<string> list = new List<string>();
            DoPermute(list, word, 0);
            return list;
        }

        private static void DoPermute(List<string> list, char[] word, int start)
        {
            //end of the word
            if (start == word.Length - 1)
            {
                list.Add(new string(word));
                return;
            }

            for (int i = start; i < word.Length; i++)
            {
                word.Swap(start, i);
                DoPermute(list, word, start + 1);
                word.Swap(start, i);
            }
        }
    }

    public static class ArrayExtensions
    {
        public static void Swap(this char[] array, int i, int j)
        {
            char ch = array[i];
            array[i] = array[j];
            array[j] = ch;
        }
    }
}
