using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class Palindrome
    {

        public static void Test()
        {
            Console.WriteLine(IsPalindrome("marge let a moody baby doom a telegram"));
        }

        //Given a string, check if it is a palindrome by ignoring spaces. E.g. race car would be a palindrome.
        public static bool IsPalindrome(string word)
        {
            int i = 0;
            int j = word.Length - 1;

            //remove unecessary spaces;
            word = word.Trim();

            //compare word[i] with word[j]
            while (i < j)
            {
                if (word[i] != word[j])
                {
                    return false;
                }

                //move pointers
                i++;
                j--;

                //find the next non space from left
                while (i < word.Length && word[i] == ' ')
                {
                    i++;
                }

                //find the next non space from right
                while (j > 0 && word[j] == ' ')
                {
                    j--;
                }

            }

            return true;
        }
    }
}
