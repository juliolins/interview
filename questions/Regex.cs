using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class Regex
    {

        public static void Test()
        {
            string text = "xxx777-26 I am going home now using flight ";

            Console.WriteLine(IndexOf(text, "7*.26"));

            //Console.WriteLine(IsMatch3("homelands", "homeland"));

            Console.WriteLine(IndexOf("bbbaleeeeexandra", "al?*x"));

            //Console.WriteLine(IsMatch3("al?", "ale"));


        }

        public static int IndexOf(string text, string regex)
        {
            return IndexOf(text.ToCharArray(), regex.ToCharArray());
        }

        public static int IndexOf(char[] text, char[] regex)
        {
            int index = 0;

            char regexChar;
            int regexIndex = 0;

            bool isNextStar = false;
            bool charMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                regexChar = regex[regexIndex];
                isNextStar = (regexIndex < regex.Length - 1 && regex[regexIndex + 1] == '*') ? true : false;

                //it's always a match
                if (regexChar == '.')
                {
                    charMatch = true;
                }
                else if (text[i] == regexChar)
                {
                    charMatch = true;

                    //need to advance
                    if (isNextStar)
                    {
                        while (text[++i] == regexChar);
                        i--;
                    }
                }
                else
                {
                    charMatch = false;
                }

                if (charMatch)
                {
                    regexIndex++;
                    if (isNextStar) regexIndex++; //pass * too
                }
                else
                {
                    //char not match
                    regexIndex = 0;
                    index = i + 1;
                }

                if (regexIndex == regex.Length)
                {
                    return index; 
                }
            }

            return -1;
        }


        static bool IsMatch(string str, string exp)
        {
            int strIndex = 0;
            int expIndex = 0;
            bool onStar = false;

            while (strIndex < str.Length)
            {
                while (exp[expIndex] == '*')
                {
                    expIndex++;
                    onStar = true;

                    if (expIndex == exp.Length)
                    {
                        return true;
                    }
                }


                if (str[strIndex] == exp[expIndex] || exp[expIndex] == '?')
                {
                    strIndex++;
                    expIndex++;

                    if (onStar) onStar = false;

                    if (expIndex == exp.Length && strIndex == str.Length)
                    {
                        return true;
                    }

                }
                else if (onStar)
                {
                    strIndex++;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }

        static bool IsMatch2(string str, string exp)
        {
            return IsMatchRec(str, exp, 0, 0);
        }

        static bool IsMatchRec(string str, string exp, int indexStr, int indexExp)
        {
            // If we reach at the end of both strings, we are done
            if (indexStr == str.Length && indexExp == exp.Length)
            {
                return true;
            }

            if (indexStr == str.Length && indexExp < exp.Length)
                return false;

            if (indexExp == exp.Length && indexStr < str.Length)
                return false;

            // Make sure that the characters after '*' are present in second string.
            // This function assumes that the first string will not contain two
            // consecutive '*' 
            if (exp[indexExp] == '*' && (indexExp + 1) < exp.Length && indexStr == str.Length)
                return false; 
            
            
            if (exp[indexExp] == '?' || str[indexStr] == exp[indexExp])
            {
                return IsMatchRec(str, exp, indexStr + 1, indexExp + 1);
            }

            // If there is *, then there are two possibilities
            // a) We consider current character of second string
            // b) We ignore current character of second string.
            if (exp[indexExp] == '*')
                return IsMatchRec(str, exp, indexStr, indexExp + 1) || IsMatchRec(str, exp, indexStr + 1, indexExp);

            return false;
        }


        static bool IsMatch3(string sentence, string expression)
        {
            int indexStr = 0, indexExp = 0;
            int indexStrTemp = 0, indexExpTemp = 0;

            while (indexStr < sentence.Length && indexExp < expression.Length)
              {  
                 if ( expression[indexExp] == '*' && (indexExp + 1) < expression.Length && indexStr == sentence.Length)
                 return false;
  
                 else if (expression[indexExp] == '?' || expression[indexExp] == sentence[indexStr])
                 {
                     indexExp++; 
                     indexStr++; 
                 }
                 else if (expression[indexExp] == '*')
                 {
                     indexExpTemp = indexExp;
                     indexStrTemp = indexStr + 1;
                     indexExp++;
                 }
                 else if (indexExpTemp == expression.Length)
                 {
                     indexExp = indexExpTemp;
                     indexStr = indexStrTemp;
                 }
                 else
                 {
                    return false;
                 }

             }// end while

            return (indexExp == expression.Length && indexStr == sentence.Length);

        }// end match

        static bool IsMatch4(string sentence, string expression)
        {
            int indexSentence = 0;
            int indexExpression = 0;

            bool onStar = false;

            while (indexSentence < sentence.Length && indexExpression < expression.Length)
            {
                while (expression[indexExpression] == '*')
                {
                    indexExpression++;
                    onStar = true;

                    if (indexExpression == expression.Length) return true;
                }


                if (onStar)
                {

                }



            }

            return false;
        }
    }
}
