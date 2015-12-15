using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Strings
{
    public class CrackingCodeInterviewStrings
    {

        public static void Test()
        {
            //char[] str = "aaaaabbb".ToCharArray();
            //Console.WriteLine(string.Format("{0} = {1}", str.Print(), RemoveDuplicates(str)));

            //string s = "the book is on the table ";
            //Console.WriteLine(s);
            //Console.WriteLine(Replace(s, "%20"));


            Console.WriteLine(string.Format("[{0}]", RemoveSpaces("  I   live   on     earth ".ToCharArray())));
        }

        //Given a string of words with lots of spaces between the words , remove all the unnecessary spaces like
        //input:  I   live   on     earth  
        //output: I live on earth
        public static string RemoveSpaces(char[] text)
        {
            int left = 0;
            bool isFirst = true;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    text[left++] = text[i];
                    isFirst = false;
                }
                else if ((i + 1 < text.Length) && text[i + 1] != ' ' && !isFirst)
                {
                    text[left++] = ' ';
                }
            }

            return new string(text, 0, left);
        }

        public static string Replace(string str, string value)
        {
            int spaceCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') spaceCount++;
            }

            char[] newString = new char[str.Length + (value.Length - 1) * spaceCount];

            int newIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    for (int j = 0; j < value.Length; j++)
                    {
                        newString[newIndex++] = value[j];
                    }
                }
                else
                {
                    newString[newIndex++] = str[i];
                }
            }

            return new string(newString);
        }

        public static string RemoveDuplicates(char[] str)
        {
            if (str == null) throw new ArgumentNullException("str");
            if (str.Length <= 1) return new string(str);

            int left = 0;

            for (int right = 1; right < str.Length; right++)
            {
                bool matched = false;
                for (int j = 0; j <= left; j++)
                {
                    if (str[j] == str[right])
                    {
                        matched = true;
                        break;
                    }
                }
                if (!matched)
                {
                    left++;
                    if (left != right) str.Swap(left, right);
                }
            }

            return new string(str, 0, left + 1);
        }

        public static string RemoveDuplicatesUnstable(char[] str)
        {
            if (str == null) throw new ArgumentNullException("str");
            if (str.Length <= 1) return new string(str);

            //unstable sort
            Array.Sort(str);

            //insertion sort (stable)
            //for (int i = 1; i < str.Length; i++)
            //{
            //    for (int j = i; j > 0; j--)
            //    {
            //        if (str[j] < str[j - 1])
            //        {
            //            str.Swap(j, j - 1);
            //        }
            //    }
            //}

            int left = 0;
            int right = 1;

            while (right < str.Length)
            {
                if (str[right] != str[left])
                {
                    left++;
                    str.Swap(left, right);
                }

                right++;
            }

            return new string(str, 0, left + 1);
        }
    }
}
