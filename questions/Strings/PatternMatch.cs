using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Strings
{
    public class PatternMatch
    {
        public static void Test()
        {
            Console.WriteLine(FindMatch("ale.*x", "aleeeeexandra"));
        }


        //Given a string and   a pattern '.' Matches any single character. 
        //'*' Matches zero or more of the preceding element.), find the first substring matching this pattern.
        public static string FindMatch(string pattern, string str)
        {
            return FindMatch(pattern, str, 0, 0);
        }

        private static string FindMatch(string pattern, string str, int startPatternIndex, int startStrIndex)
        {
            int patternIndex = startPatternIndex;
            int strIndex = startStrIndex;

            while (strIndex < str.Length && patternIndex < pattern.Length)
            {
                if (pattern[patternIndex] != '*')
                {
                    if (!IsCharMatch(pattern[patternIndex], str[strIndex]))
                    {
                        strIndex = strIndex - (patternIndex - startPatternIndex);
                        patternIndex = startPatternIndex;
                    }
                    else
                    {
                        patternIndex++;
                        strIndex++;
                    }
                }
                else if (pattern[patternIndex - 1] == '.') //got a '.*', break into another part
                {
                    string part = FindMatch(pattern, str, patternIndex + 1, strIndex + 1);
                    if (!part.Equals(string.Empty))
                    {
                        return str.Substring(startStrIndex, strIndex - startStrIndex) + part;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else //'A*'
                {
                    while (str[strIndex] == pattern[patternIndex - 1] && strIndex < str.Length)
                    {
                        strIndex++;
                    }
                }
            }

            if (patternIndex == pattern.Length)
            {
                return str.Substring(startStrIndex, strIndex - startStrIndex);
            }
            else
            {
                return string.Empty;
            }

        }

        private static bool IsCharMatch(char patternChar, char strChar)
        {
            return patternChar == '.' || patternChar == strChar;
        }
    }
}
