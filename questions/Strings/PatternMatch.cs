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
            Console.WriteLine(IsMatch2("aleeeeexandra", "b*x"));
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

        public static bool IsMatch2(string str, string pattern)
        {
            return IsMatch2(str, pattern, 0, 0);
        }

        public static bool IsMatch2(string str, string pattern, int strIndex, int patternStartIndex)
        {
            int patternIndex = patternStartIndex;

            while (patternIndex < pattern.Length && strIndex < str.Length)
            {
                //* means 0 or more so we can basically ignore the current char in the pattern
                //and recursively check for the next char in the pattern
                if (IsNextStar(pattern, patternIndex + 1))
                {
                    return IsMatch2(str, pattern, strIndex, patternIndex + 2);
                }
                else if (IsCharMatch(str, pattern, strIndex, patternIndex))
                {
                    patternIndex++;
                }
                else
                {
                    //not a match, return to start of pattern
                    patternIndex = patternStartIndex;
                }

                strIndex++;
            }

            //return true if we ran out of the pattern instead of running out of the str
            //>= because of the recursive call that has a "+2" for the patternIndex
            return patternIndex >= pattern.Length;
        }

        private static bool IsNextStar(string pattern, int index)
        {
            return index < pattern.Length && pattern[index] == '*';
        }

        private static bool IsCharMatch(string str, string pattern, int strIndex, int patternIndex)
        {
            return pattern[patternIndex] == '.' || pattern[patternIndex] == str[strIndex];
        }
    }
}
