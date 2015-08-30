using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class PossibleTriangles
    {

        public static void Test()
        {
            int[] array = new int[] { 4, 6, 3, 7 };

            Console.WriteLine(CountTriangles(array));
        }


        public static int CountTriangles(int[] array)
        {
            return DoCountTriangles(array, 0, new int[3], 0);
        }


        private static int DoCountTriangles(int[] array, int arrayIndex, int[] sides, int sideIndex)
        {
            //cannot form a triangle (not enouth elements left)
            if (array.Length - arrayIndex < 3 - sideIndex)
            {
                return 0;
            } 


            //we have a set of three elemtsn: a triangle can possibly be formed 
            if (sideIndex == 3)
            {
                //return 1 is it's a triagle (and break the recursion anyway)
                if (IsTriangle(sides[0], sides[1], sides[2]))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            //triangle count
            int count = 0;

            //combine elements in sets of 3
            for (int i = arrayIndex; i < array.Length; i++)
            {
                //current element
                sides[sideIndex] = array[i];

                //choose next side recursivelly
                count = count + DoCountTriangles(array, i + 1, sides, sideIndex + 1);
            }

            return count;
        }

        //checks if 3 sides can form a triangle
        private static bool IsTriangle(int a, int b, int c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a); 
        }
    }
}
