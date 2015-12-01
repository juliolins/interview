using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Microsoft
{
    class Palindrome
    {
        int CountPalindrome(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                count += CountFromIndex(str, i);
            }

            return count;
        }

        int CountFromIndex(string str, int left)
        {
            int right = left + 1;

            while (left >= 0 && right < str.Length)
            {
                if (str[left] != str[right])
                {
                    //break if they don't match
                    break;
                }

                left--;
                right++;
            }

            return right - left - 1;
        }
    }

}
