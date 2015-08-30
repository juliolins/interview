using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class Parentesis
    {

        public static void Test()
        {
            //List<string> set = GetPar(3);

            //foreach (string item in set)
            //{
            //    Console.WriteLine("\"" + item + "\"");
            //}

            //int count = 3;
            //char[] word = new char[count * 2];
            //List<string> list = new List<string>();
            //GeneratePar(list, count, count, word, 0);

            //foreach (string item in list)
            //{
            //    Console.WriteLine("\"" + item + "\"");
            //}


            Console.WriteLine(Sqrt(612, 5));

        }


        public static List<string> GetPar(int n)
        {
            if (n == 0)
            {
                //empty string
                List<string> set = new List<string>();
                set.Add("");
                return set;
            }
            //else if (n == 1)
            //{
            //    List<string> set = GetPar(0);
            //    set.Add("()");
            //    return set;
            //}
            else
            {
                List<string> set = GetPar(n - 1);
                List<string> tempSet = new List<string>();

                foreach (string item in set)
                {
                    tempSet.Add("(" + item + ")");
                    tempSet.Add(item + "()");
                }

                set.AddRange(tempSet);

                return set;
            }
        }

        public static void GeneratePar(List<string> list, int leftRem, int rightRem, char[] word, int count)
        {
            if (leftRem < 0 || rightRem < leftRem) return; //invalid

            if (leftRem == 0 && rightRem == 0)
            {
                list.Add(new string(word, 0, count));
            }
            else
            {
                if (leftRem > 0)
                {
                    word[count] = '(';
                    GeneratePar(list, leftRem - 1, rightRem, word, count + 1);
                }

                if (rightRem > leftRem)
                {
                    word[count] = ')';
                    GeneratePar(list, leftRem, rightRem - 1, word, count + 1);
                }
            }
        }


        public static float Sqrt(int x, int precision)
        {
            int count = 0;
            int sum = 1;

            //integer part
            while (sum <= x)
            {
                sum = sum * 2;
                count++;
            }

            // remove last
            //count--;
            sum = sum / 2;
            

            //now use Newton's method
            float root = 22;
            for (int i = 0; i < precision; i++)
			{
                root = root - (root * root - x) / (2 * root);
			}

            return root;
        }
    }
}
