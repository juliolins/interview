using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    //[Facebook-Screen]Write a function void div(int a, int b, int* result, int*
    //remaining) without division or modulus operator. Tip: the trivial solution
    //O(a/b) is not the one the interviewer is looking for.

    public class Division
    {
        public static void Test()
        {
            int result, remaining;

            Devide(20, 4, out result, out remaining);

            Console.WriteLine("result = " + result + " remaining = " + remaining);
        }

        public static void Devide(int a, int b, out int result, out int remaining)
        {
            result = 0;
            while (a >= b)
            {
                a = a - b;
                result++;
            }
            remaining = a;
        }
    }
}
