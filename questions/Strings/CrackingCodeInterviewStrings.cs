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
            char[] str = "bbaac".ToCharArray();
            Console.WriteLine(string.Format("{0} = {1}", str.Print(), RemoveDuplicates(str)));
        }


        public static string RemoveDuplicates(char[] str)
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
