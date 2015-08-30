using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class ReverseString
    {

        public static void TestReverse()
        {
            //char[] word = "table the on is book the".ToCharArray();
            //ReverseSetence(word);
            //Console.WriteLine(word);

            char[] sentence = "the book is on the table".ToCharArray();
            sentence = ShuffleWords(sentence);
            Console.WriteLine(sentence);
        }


        public static void ReverseWord(char[] word)
        {
            ReverseWord(word, 0, word.Length - 1);
        }

        public static void ReverseWord(char[] word, int start, int end)
        {
            for (int i = 0; i <= (end - start) / 2; i++)
            {
                char temp = word[start + i];
                word[start + i] = word[end - i];
                word[end - i] = temp;
            }
        }


        public static void ReverseSetence(char[] sentence)
        {
            ReverseWord(sentence);
            Console.WriteLine(sentence);

            int wordStart = 0;
            int wordEnd = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ')
                {
                    wordEnd = i - 1;
                    ReverseWord(sentence, wordStart, wordEnd);
                    wordStart = i + 1;
                }
                else if (i == sentence.Length - 1)
                {
                    ReverseWord(sentence, wordStart, i);
                }

            }
        }

        //[Microsoft-Screen]Given a string with words, return another string which has the words shuffled.
        public static char[] ShuffleWords(char[] sentence)
        {
            char[] result = new char[sentence.Length];
            int resultPosition = 0;
            int wordCount = CountWords(sentence);
            
            //generate array with new positions
            int[] allocation = GetRandomAllocation(wordCount);

            //wordCount times pick a word and put it in the new array
            for (int i = 0; i < wordCount; i++)
            {
                int wordNumber = allocation[i];
                int currentWord = 0;
                int wordStart = 0;

                for (int j = 0; j < sentence.Length; j++)
                {
                    if (sentence[j] == ' ' || j == sentence.Length - 1)
                    {
                        currentWord++;

                        //if this words turn to move
                        if (currentWord == wordNumber)
                        {
                            //copy word
                            for (int k = wordStart; k < j - 1; k++)
                            {
                                result[resultPosition++] = sentence[k];
                            }

                            if (j < sentence.Length - 1)
                            {
                                result[resultPosition++] = ' '; //add space if not at the end
                            }
                        }
                        else
                        {
                            wordStart = j + 1;
                        }
                    }
                }
            }

            return result;
        }

        public static int CountWords(char[] sentence)
        {
            int count = 0;

            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ')
                {
                    count++;
                }
            }

            return count + 1; //+1 for the last word
        }

        public static int[] GetRandomAllocation(int wordCount) 
        {
            Random random = new Random();
            int[] allocation = new int[wordCount];

            for (int i = 0; i < allocation.Length; i++)
            {
                allocation[i] = i + 1;
            }

            for (int i = 0; i < allocation.Length; i++)
            {
                int newPosition = random.Next(0, allocation.Length);
                int temp = allocation[newPosition];
                allocation[newPosition] = allocation[i];
                allocation[i] = temp;
            }

            return allocation;
        }
    }
}
