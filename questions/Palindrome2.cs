using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class Palindrome2
    {

        public static void Test()
        {
            Check("race car");
            Check("race bike");
        }

        private static void Check(string sentence)
        {
            Console.WriteLine(string.Format("{0} = {1}", sentence, IsPalindrome(sentence)));
        }


        public static bool IsPalindrome(string sentence)
        {
            int left = 0;
            int right = sentence.Length - 1;

            while (left < right)
            {
                if (sentence[left] == ' ')
                {
                    left++;
                    continue;
                }
                else if (sentence[right] == ' ')
                {
                    right--;
                    continue;
                }
                else
                {
                    if (sentence[left] != sentence[right])
                    {
                        return false;
                    }

                    left++;
                    right--;
                }
            }

            return true;
        }
    }
}
