using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    /// <summary>
    /// http://www.geeksforgeeks.org/find-all-possible-interpretations/
    /// </summary>
    public class ArrayOfDigits
    {
        public static void Test()
        {
            var results = Interpret(new int[] { 1, 2, 1});

            results.PrintToConsole();
        }


        public static IEnumerable<string> Interpret(int[] array)
        {
            List<string> results = new List<string>();
            DoInterpret(results, array, new Stack<string>(), 0);
            return results;
        }

        private static void DoInterpret(List<string> results, int[] array, Stack<string> stack, int start)
        {
            if (start == array.Length)
            {
                results.Add(stack.ToSingleString());
                return;
            }

            //select one
            stack.Push(GetString(array, start));
            DoInterpret(results, array, stack, start + 1);
            stack.Pop();

            //select two
            if (start < array.Length - 1)
            {
                stack.Push(GetString(array, start, start + 1));
                DoInterpret(results, array, stack, start + 2);
                stack.Pop();
            }
        }

        private static string GetString(int[] array, int index)
        {
            return GetString(array, index, index);
        }

        private static string GetString(int[] array, int start, int end)
        {
            if (start == end)
            {
                return ((char) (array[start] - 1 + 'a')) + "";
            }
            else
            {
                return ((char) (array[start] * 10 + array[end] - 1 + 'a')) + "";
            }
        }
    }

    public static class StackExt
    {
        public static string ToSingleString(this Stack<string> stack)
        {
            string[] array = stack.ToArray();
            StringBuilder sb = new StringBuilder(array.Length * 2);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sb.Append(array[i]);
            }

            return sb.ToString();
        }
    }

}
