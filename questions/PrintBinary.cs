using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingQuestions
{
    public class PrintBinary
    {
        public static void Test()
        {
            Print2(0);
        }


        public static void Print(int n)
        {
            while (n > 0)
            {
                Console.Write(n % 2);
                n = n / 2;
            }
            Console.WriteLine();
        }

        public static void Print2(int n)
        {
            int check = 1;

            for (int i = 0; i < 32; i++)
            {
                if ((n & check) == check)
                {
                    Console.Write('1');
                }
                else
                {
                    Console.Write('0');
                }

                check = check << 1;
            }
            Console.WriteLine();

        }
    }
}
