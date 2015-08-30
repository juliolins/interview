using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    class TextReassemble
    {
        private static Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
        private static int WORD_MAX_SIZE;

        public static void Test()
        {
            string text = "video provides a powerful way to help you prove your point";
            char[] textCripped = "videoprovidesapowerfulwaytohelpyouproveyourpoint".ToCharArray();
            CreateDictionary(text);

            Console.WriteLine(RecoverText(textCripped));
            
        }

        public static string RecoverText(char[] text)
        {
            string recoveredText = "";

            int index = 0;
            int wordSize = 0;
            int wordBegin = 0;
            int charsOut = 0;
            bool found = false;

            while (index < text.Length)
            {
                wordBegin = index + charsOut;
                wordSize = Math.Min(WORD_MAX_SIZE, text.Length - wordBegin);


                while (wordSize > 0)
                {
                    string word = new string(text, wordBegin, wordSize);
                    if (dictionary.ContainsKey(word))
                    {
                        recoveredText = recoveredText + word + " ";
                        found = true;
                        break;
                    }

                    wordSize--;
                }

                if (found)
                {
                    if (charsOut > 0)
                    {
                        string newWord = new string(text, index, charsOut);
                        recoveredText = recoveredText + newWord.ToUpper() + " ";
                        index = index + charsOut + wordSize;
                        charsOut = 0;
                    }
                    else
                    {
                        index = index + wordSize;
                    }

                    found = false;
                }
                else
                {
                    charsOut++;
                }
            }

            return recoveredText;
        }

        public static void CreateDictionary(string text)
        {
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "powerful")
                dictionary.Add(words[i].Trim(), true);

                if (words[i].Length > WORD_MAX_SIZE)
                {
                    WORD_MAX_SIZE = words[i].Length;
                }
            }
        }

    }
}
