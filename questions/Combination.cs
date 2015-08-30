using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class Combination
    {

        public static void Test()
        {
            Combine("abcd".ToCharArray(), new char[3], 0, true, new bool[4]);
            Console.WriteLine(count);
        }

        static int count = 0;

        public static void Combine(char[] alphabet, char[] word, int startWord, bool repeat, bool[] skipArray) 
        {
            if (startWord == word.Length)
            {
                Print(word);
                count++;
                return;
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (repeat)
                {
                    if (!skipArray[i])
                    {
                        word[startWord] = alphabet[i];
                        skipArray[i] = true;
                        Combine(alphabet, word, startWord + 1, repeat, skipArray);
                        skipArray[i] = false;
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    word[startWord] = alphabet[i];
                    Combine(alphabet, word, startWord + 1, repeat, skipArray);
                    continue;
                }

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

    }
}
