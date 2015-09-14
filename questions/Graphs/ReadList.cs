using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions.Graphs
{
    //http://www.geeksforgeeks.org/optimal-read-list-given-number-days/
    public class ReadList
    {

        public static List<int>[] CreateReadList(int[] chapters, int days, int start)
        {
            List<int>[] readList = new List<int>[days];
            int average = chapters.Sum() / days;


            return readList;
        }

        private static void BuildList(int[] chapters, int daysLeft, int start) 
        {

            int mySum = 0;
            for (int i = start; i < chapters.Length - daysLeft; i++)
            {
                mySum += chapters[i];
            }

        }

    }
}
