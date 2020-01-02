using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    public class BigInt2
    {
        private int[] current = new int[20];

        public BigInt2(int x)
        {
            Add(x);
        }


        public void Add(int x)
        {
            if (x == 0)
            {
                return;
            }

            int index = current.Length - 1;
            int rest = 0;
            int unit = 0;

            while ((x > 0 || rest > 0) && index >= 0)
            {
                //get current unit
                if (x > 0)
                {
                    unit = x % 10;
                }
                else
                {
                    unit = 0;
                }

                //add current unit plus previous rest
                current[index] = current[index] + unit + rest;

                //rest has been used
                rest = 0;

                if (current[index] >= 10)
                {
                    current[index] = current[index] % 10;
                    rest = 1; //new rest
                }

                x = x / 10;
                index--;
            }
        }

        public void Multiply(int x)
        {
            int[] temp = new int[20];
            int index = current.Length - 1;
            int unit = 0;
            int rest = 0;
            int count = 0;

            while (x > 0)
            {
                unit = x % 10;
                index = current.Length - 1;

                while (index - count >= 0)
                {
                    //calculate unit multiplcation
                    int result = unit * current[index] + rest;

                    //keep unit
                    temp[index - count] = temp[index - count] + result % 10;

                    //save rest
                    rest = result / 10;

                    if (temp[index - count] >= 10)
                    {
                        rest = rest + temp[index - count] / 10;
                        temp[index - count] = temp[index - count] % 10;
                    }

                    index--;
                }

                count++;
                x = x / 10;
            }

            current = temp;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(current.Length);

            bool print = false;

            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] > 0)
                    print = true;

                if (print) builder.Append(current[i]);
            }

            return builder.ToString();
        }

        public static void Test()
        {
            //BigInt2 big = new BigInt2(2147483647);
            //big.Add(2147483647);
            //big.Add(2147483647);
            //2020 test


            BigInt2 big = new BigInt2(999999999);
            big.Multiply(999999999);

            Console.WriteLine(big);

        }
    }
}
