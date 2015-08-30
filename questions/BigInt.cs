using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingQuestions
{
    //2.147.483.647

    //1.000.000.000



    public class BigInt
    {
        private int current;
        private int stackCount = 0;

        private const int MAX_VALUE = 1000000000;
        private const int MIN_VALUE = -1000000000;

        public void Add(BigInt big)
        {
            //add stacks
            this.stackCount = this.stackCount + big.stackCount;

            //add current
            Add(big.current);
        }

        public void Add(int x)
        {
            x = MergeToStack(x);
            current = current + x;
            current = MergeToStack(current);
        }

        public void Multiply(BigInt big)
        {
            //(a + x) * (b + y) = a*b + a*y + x*b + x*y;


            //multiply stacks (a*b)
            int newStack = this.stackCount * big.stackCount;

            //stack * current of big (a*y)
            newStack = newStack + this.stackCount * big.current;
            
            //stack of big * this current (x*b)
            newStack = newStack + big.stackCount * this.current;

            //x*y
            BigInt x_y = IntMultiply(this.current, big.current);
            this.Add(x_y);
        }

        private BigInt IntMultiply(int a, int b)
        {
            BigInt result = new BigInt();

            for (int i = 0; i < b; i++)
            {
                result.Add(a);
            }

            return result;
        }

        private int MergeToStack(int x)
        {
            if (Math.Abs(x) < MAX_VALUE)
            {
                return x;
            }

            stackCount = stackCount + (x / MAX_VALUE);
            return x % MAX_VALUE;
        }

        public override string ToString()
        {
            if (stackCount == 0)
            {
                return current.ToString();
            }
            else
            {
                return stackCount.ToString() + string.Format("{0:D9}", current);
            }
        }


        public static void Test()
        {
            //Console.WriteLine(int.MaxValue);

            BigInt bigA = new BigInt();
            BigInt bigB = new BigInt();

            //1000000000
            //999999999
            //11000000000
            bigA.Add(500000000);
            bigB.Add(888888888);

            bigA.Multiply(bigB);

            Console.WriteLine(bigA);

            //int x = -22;
            //Console.WriteLine(x % 4);

        }
    }
}
