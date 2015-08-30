using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class LSDTest
    {
        public static void Test()
        {
            string[] names = new string[] { "julio", "cesar", "sants", "linsa", "cesbt" };

            LSD.Sort(ref names, 5);

            Console.WriteLine(names.Print());

        }

    }


    //least significant digit (LSD) radix sort
    public class LSD
    {
        public static void Sort(ref string[] lines, int maxLength)
        {
            int[] countTable = new int[27];

            //main loop: starts from right to left on strings
            for (int column = maxLength - 1; column >= 0; column--)
            {
                
                //assemble the count
                for (int i = 0; i < lines.Length; i++)
                {
                    int pos = GetTablePosision(lines, i, column);
                    countTable[pos]++;
                }

                //calculate the totals
                for (int i = 1; i < countTable.Length; i++)
                {
                    countTable[i] = countTable[i] + countTable[i - 1];
                }

                //put lines in place
                string[] linesDestination = new string[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    //copy string to new place
                    int pos = countTable[GetTablePosision(lines, i, column)] - 1;

                    linesDestination[pos]= lines[i];
                    
                    //increment char position
                    countTable[GetTablePosision(lines, i, column)]++;
                }

                //clean counts
                for (int i = 0; i < countTable.Length; i++)
                {
                    countTable[i] = 0;
                }

                //copy new sorted string
                lines = linesDestination;
            }
        }

        /// <summary>
        /// Returns the count table position for a given char.
        /// </summary>
        private static int GetTablePosision(string[] lines, int index, int column)
        {
            if (column >= lines[index].Length)
            {
                return 0;
            }
            else
            {
                char ch = lines[index][column];
                int res = ch - 'a' + 1;
                if (res == 15)
                {
                    return res;
                } 

                return res;
            }
        }

        /// <summary>
        /// Returns true if CharAt(indexA) <= CharAt(indexB)
        /// </summary>
        private static bool IsLess(int indexA, int indexB, string[] lines, int column)
        {
            if (column >= lines[indexA].Length)
            {
                return true;
            }
            else if (column >= lines[indexB].Length)
            {
                return false;
            }
            else
            {
                return lines[indexA][column] <= lines[indexB][column];
            }

        }
    }
}
