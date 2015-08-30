using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class DetecOddNumber
    {

        public static void TestDetectOdd()
        {
            int[] array = new int[] {1, 1, 1, 1, 2, 2, 3, 3, 4};

            int result = DetectOdd(array);

            Console.WriteLine("result = " + result);
        }


        public static int DetectOdd(int[] array)
        {
            int numberCount = 0;
            int lastNumber = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == lastNumber)
                {
                    //same number, keep counting
                    numberCount++;
                }
                else
                {
                    //changed numbers, is count odd?
                    if (numberCount % 2 == 1)
                    {
                        return lastNumber;
                    }
                    else if (i == array.Length - 1)
                    {
                        return array[i]; //return last number which is different
                    }
                    else
                    {
                        //if even, simply update lastNumber
                        lastNumber = array[i];
                        numberCount = 1;
                    }
                }
            }

            return -1;
        }
    }
}
